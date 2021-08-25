using System;

namespace DS.Domain.ClientControll
{
    public abstract class PessoaFisica : DocumentoPessoaFisica
    {
        public string nome { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string cep { get; set; }
        public string uf { get; set; }
        public string complemento { get; set; }
        public DateTime data_nascimento { get; set; }
    }
}
