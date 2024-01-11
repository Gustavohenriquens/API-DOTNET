using EstoqueDeSapatos.API.Entities;

namespace EstoqueDeSapatos.API.Persistence
{
    public class BancoDeDadosF
    {
        public List<FEstoqueEntities> fEstoqueEntities { get; set; }

        public BancoDeDadosF()
        {
            fEstoqueEntities = new List<FEstoqueEntities>();
        }
    }
}
