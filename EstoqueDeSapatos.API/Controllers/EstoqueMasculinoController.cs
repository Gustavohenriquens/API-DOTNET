using EstoqueDeSapatos.API.Models;
using EstoqueDeSapatos.API.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace EstoqueDeSapatos.API.Controllers
{
	[Route("api/estoqueMasculino")]
	[ApiController]
	public class EstoqueMasculinoController : ControllerBase
	{
		private readonly BancoDeDadosM _db;

        public EstoqueMasculinoController(BancoDeDadosM db)
        {
			_db = db;
        }

		[HttpGet]
		public IActionResult GetAll()
		{
			var exibirTodosOsEstoques = _db.mEstoqueEntities.Where(e => !e.IsDeleted).ToList();
			// Será uma lista de entidades mEstoqueEntities que não foram marcadas como excluídas (IsDeleted é false).
			// ToList(): Converte o resultado da consulta em uma lista.

			return Ok(exibirTodosOsEstoques);
		}


		[HttpGet("{id}")]
		public IActionResult GetById(Guid id)
		{
			var pegarEstoqueApartirDoId = _db.mEstoqueEntities.SingleOrDefault(e => e.IdProduto == id);
			// Está sendo usado para encontrar uma única entidade que satisfaça a condição especificada.
			// É usada para localizar uma entidade com um ID específico no banco de dados.

			if (pegarEstoqueApartirDoId == null)
			{
				return NotFound(); //Erro de não encontrado.
			}

			return Ok(pegarEstoqueApartirDoId);

		}

		[HttpPost]
		public IActionResult Post(MEstoqueEntities mEstoque)
		//MEstoqueEntities é um tipo de dado, e mEstoque é o nome da variável que representa um objeto dessa classe. 
		{
			_db.mEstoqueEntities.Add(mEstoque); // Essa linha efetivamente adiciona um novo registro ao banco de dados.

			// Retorna uma resposta de sucesso (código 201 - Created) com detalhes do recurso criado
			return CreatedAtAction(nameof(Post), new { id = mEstoque.IdProduto }, mEstoque);

			// Se o modelo não for válido, retorne uma resposta de erro (código 400 - Bad Request)
			//return BadRequest(ModelState);
		}



		[HttpPut("{id}")]
		public IActionResult Update(Guid id, MEstoqueEntities input)
		{
			var atualizarProdutoApartirDoId  = _db.mEstoqueEntities.SingleOrDefault(e => e.IdProduto == id);

			if (atualizarProdutoApartirDoId == null)
			{
				return NotFound();
			}

            atualizarProdutoApartirDoId.Update(input.NomeProduto, input.QuantidadeProduto, input.DescricaoProduto); // Pega objetos que estão na estrutura de dados.

			return NoContent();
		}	


		[HttpDelete("{id}")]	
		public IActionResult Delete(Guid id)
		{
			var deletarProdutoApartirDoId = _db.mEstoqueEntities.SingleOrDefault(d => d.IdProduto == id);

			if (deletarProdutoApartirDoId == null)
			{
				return NotFound(); 
			}

            deletarProdutoApartirDoId.Delete();


			return NoContent();
		}



	}
}
