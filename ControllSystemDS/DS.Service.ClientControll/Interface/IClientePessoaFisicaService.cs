using System.Collections.Generic;
using DS.Domain.ClientControll;

namespace DS.Service.ClientControll.Interface
{
    public interface IClientePessoaFisicaService
    {
        List<ClientePessoaFisica> Get();
        ClientePessoaFisica Get(int codigo);
        int Insert(ClientePessoaFisica clientePessoaFisica);
        int Update(ClientePessoaFisica clientePessoaFisica);
        int Delete(int id);
    }
}
