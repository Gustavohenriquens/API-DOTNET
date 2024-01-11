using EstoqueDeSapatos.API.Models;

namespace EstoqueDeSapatos.API.Persistence
{
	public class BancoDeDadosM
	{

		public List<MEstoqueEntities> mEstoqueEntities {  get; set; }
		
		public BancoDeDadosM()
		{
			mEstoqueEntities = new List<MEstoqueEntities>();

		}

	}
}
