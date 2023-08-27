using DS.Domain.ClientControll;
using System.Collections.Generic;

namespace IntegrationTest.DS.ClientControllSystem.Response
{
    public class ResponseGetClientesPessoaFisica : ResponseBase
    {
        public List<ClientePessoaFisica> data { get; set; }
    }
}
