namespace DS.Domain.ClientControll
{
    public abstract class DocumentoPessoaFisica : EntityBase
    {
        public string cpf { get; set; }
        public string rg { get; set; }
        public string certidao_nascimento { get; set; }
        public string certidao_casamento { get; set; }
        public string titulo_eleitor { get; set; }
        public string reservista { get; set; }
    }
}
