using System.Collections.Generic;
using System.Linq;
using DS.Domain.ClientControll;
using DS.Infrastructure.ClientControll.Repository.Interface;
using DS.Infrastructure.ClientControll.Repository.Config;
using Microsoft.EntityFrameworkCore;

namespace DS.Infrastructure.ClientControll.Repository
{
    public class ClientePessoaFisicaRepository : RepositoryBase<ClientePessoaFisica>, IClientePessoaFisicaRepository
    {
        public ClientePessoaFisicaRepository(ApplicationDBContext context) : base(context)
        {
        }

        public ClientePessoaFisica SearchCpf(string cpf)
        {
            ClientePessoaFisica clientePessoaFisica = context.Set<ClientePessoaFisica>().Where(x => x.cpf == cpf)
                                                                                    .AsNoTracking().FirstOrDefault();
            return clientePessoaFisica;
        }

        //Essa consulta consiste em retornar a classe Aluno e todas suas entidades filhas
        public ClientePessoaFisica FullSearch(ClientePessoaFisica cliente)
        {
            ClientePessoaFisica clientePessoaFisica = context.Set<ClientePessoaFisica>().
                                                                        Where(a => a.codigo == cliente.codigo).Single(); 
            return clientePessoaFisica;
        }

        //Essa listagem consiste em retornar a classe Aluno e todas suas entidades filhas
        public List<ClientePessoaFisica> FullList()
        {
            List<ClientePessoaFisica> clientePessoaFisica = context.Set<ClientePessoaFisica>().
                                                                    Include(a => a.cpf).OrderBy(a => a.nome).ToList();
            return clientePessoaFisica;
        }
    }
}
