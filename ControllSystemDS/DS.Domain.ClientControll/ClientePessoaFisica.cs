using System;

namespace DS.Domain.ClientControll
{
    public class ClientePessoaFisica : PessoaFisica
    {
        public string apelido { get; set; }
        public string email { get; set; }
        public string foto { get; set; }
        public string rede_social { get; set; }
        public string aplicativo_mensagem { get; set; }
        public string telefone_residencial { get; set; }
        public string telefone_celular { get; set; }
        public string biometria { get; set; }
        public bool ativo { get; set; }
    }
}
