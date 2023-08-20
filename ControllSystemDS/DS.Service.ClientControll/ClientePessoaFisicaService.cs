using System;
using System.Collections.Generic;
using DS.Service.ClientControll.Interface;
using DS.Infrastructure.ClientControll.Repository.Interface;
using DS.Domain.ClientControll;
using DS.Infrastructure.Utils.ClientControll;

namespace DS.Service.ClientControll
{
    public class ClientePessoaFisicaService : IClientePessoaFisicaService
    {
        private readonly IClientePessoaFisicaRepository _repository;
        private readonly NotificationContext _notificationContext;

        public ClientePessoaFisicaService(IClientePessoaFisicaRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<ClientePessoaFisica> Get()
        {
            try
            {
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<ClientePessoaFisica> listaClientePessoaFisica = _repository.FullList();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return listaClientePessoaFisica;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }
            return null;
        }

        public ClientePessoaFisica Get(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                ClientePessoaFisica clientePessoaFisica = _repository.SelectById(codigo);
                clientePessoaFisica = _repository.FullSearch(clientePessoaFisica);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
                return clientePessoaFisica;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(ClientePessoaFisica cliente)
        {
            try
            {
                cliente.rg = Util.removeCaracteresEspeciais(cliente.rg);
                cliente.cpf = Util.removeCaracteresEspeciais(cliente.cpf);
                cliente.telefone_celular = Util.removeCaracteresEspeciais(cliente.telefone_celular);
                cliente.telefone_residencial = Util.removeCaracteresEspeciais(cliente.telefone_residencial);

                Log.write(Log.Nivel.INFO, "CPF = " + cliente.cpf + " IN");
                ClientePessoaFisica ClientePessoaFisicaExiste = _repository.SearchCpf(cliente.cpf);

                if (ClientePessoaFisicaExiste == null)
                {
                    Log.write(Log.Nivel.INFO, "CPF = " + cliente.cpf + " OUT");
                    int codigoClienteInserido = _repository.Insert(cliente);
                    return codigoClienteInserido;
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "Já existe um cadastro para esse CPF OUT");
                    _notificationContext.AddNotification("Já existe um cadastro para esse CPF.");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir esse cadastro.");
            }
            return 0;
        }

        public int Update(ClientePessoaFisica cliente)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "CPF = " + cliente.cpf + " IN");
                ClientePessoaFisica clienteExistente = _repository.SearchCpf(cliente.cpf);

                if (clienteExistente != null)
                {
                    _repository.Update(cliente);
                    Log.write(Log.Nivel.INFO, "CPF = " + cliente.cpf + " OUT");
                }
                else
                {
                    Log.write(Log.Nivel.INFO, "CPF = " + cliente.cpf + " Aluno não encontrado OUT");
                    _notificationContext.AddNotification("Aluno não encontrado.");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                ClientePessoaFisica cliente = _repository.SelectById(codigo);

                if (cliente == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + ", Este cadastro não foi encontrado no banco de dados OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }

                _repository.Delete(cliente);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel deletar.");
                _notificationContext.AddNotification(ex.Message);
            }

            return 0;
        }
    }
}
