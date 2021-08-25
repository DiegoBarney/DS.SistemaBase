using System.Collections.Generic;
using DS.Domain.ClientControll;

namespace DS.Infrastructure.ClientControll.Repository.Interface
{
    public interface IClientePessoaFisicaRepository : IRepositoryBase<ClientePessoaFisica>
    {
        public ClientePessoaFisica SearchCpf(string cpfDoClientePessoaFisica);
        public ClientePessoaFisica FullSearch(ClientePessoaFisica clientePessoaFisica);
        public List<ClientePessoaFisica> FullList();
    }
}
