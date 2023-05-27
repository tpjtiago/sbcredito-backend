namespace SBcredito.Domain.Entities
{
    public class TituloAnalise : BaseEntity
    {
        public string CNPJ { get; set; }
        public string NomeSacado { get; set; }
        public string Telefone { get; set; }
        public int CEP { get; set; }
        public string EnderecoCobranca { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public DateTime DataEmissao { get; set; }
        public decimal ValorFace { get; set; }
        public decimal ValorDesconto { get; set; }
    }
}
