using EstoqueDeSapatos.API.Entities;
using EstoqueDeSapatos.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueDeSapatos.API.Controllers
{
    [Route("api/estoqueFeminino")]
    [ApiController]
    public class EstoqueFemininoController : ControllerBase
    {
        private readonly BancoDeDadosF _db;

        public EstoqueFemininoController(BancoDeDadosF db)
        {
            _db = db;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var exibirTodosOsEstoques = _db.fEstoqueEntities.Where(x => !x.IsDeleted).ToList();
                
            return Ok(exibirTodosOsEstoques);
        }



        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var pegarEstoqueApartirDoId = _db.fEstoqueEntities.SingleOrDefault(x => x.IdProduto == id);

           if(pegarEstoqueApartirDoId == null)
            {
                return NotFound();
            }

            return Ok(pegarEstoqueApartirDoId);
        }



        [HttpPost]
        public IActionResult CadastrarProduto(FEstoqueEntities fProduto)
        {
            _db.fEstoqueEntities.Add(fProduto);

            return CreatedAtAction(nameof(CadastrarProduto), new { id = fProduto.IdProduto }, fProduto);
        }



        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(Guid id, FEstoqueEntities input)
        {
            var atualizarProdutoApartirDoId = _db.fEstoqueEntities.SingleOrDefault(x => x.IdProduto == id);

            if (atualizarProdutoApartirDoId == null)
            {
                return NotFound();
            }

            atualizarProdutoApartirDoId.Update(input.NomeProduto, input.QuantidadeProduto, input.DescricaoProduto);

            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(Guid id)
        {

            var deletarProdutoApartirDoId = _db.fEstoqueEntities.FirstOrDefault(x => x.IdProduto == id);

            if (deletarProdutoApartirDoId == null)
            {
                return NotFound();
            }

            deletarProdutoApartirDoId.Delete();

            return NoContent();
        }


    }
}
