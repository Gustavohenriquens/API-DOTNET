namespace EstoqueDeSapatos.API.Entities
{
    public class FEstoqueEntities
    {
        public FEstoqueEntities()
        {
            IsDeleted = false;
        }
        public Guid IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public bool IsDeleted { get; set; }


        public void Update(string nomeProduto, int quantidadeProduto, string descricaoProduto)
        {
            NomeProduto = nomeProduto;
            QuantidadeProduto = quantidadeProduto;
            DescricaoProduto = descricaoProduto;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }

}
