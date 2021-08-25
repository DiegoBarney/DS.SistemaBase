using System;
using System.Collections.Generic;
using DS.Infrastructure.ClientControll.Repository.Interface;
using DS.Infrastructure.Utils.ClientControll;
using DS.Service.ClientControll.Interface;
using DS.Domain.ClientControll;

namespace DS.Service.ClientControll
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly NotificationContext _notificationContext;

        public UserService(IUserRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public List<User> Get()
        {
            try
            {
                Log.write(Log.Nivel.INFO, "<List> IN");
                List<User> Users = _repository.Get();
                Log.write(Log.Nivel.INFO, "<List> OUT");
                return Users;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "<List> OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public User Get(User user)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "UserName = " + user.username + ", Password = " + user.password + " IN");
                User User = _repository.Get(user.username, user.password);
                Log.write(Log.Nivel.INFO, "UserName = " + user.username + ", Password = " + user.password + " OUT");
                return User;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "UserName = " + user.username + ", Password = " + user.password + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel capturar as informações.");
            }

            return null;
        }

        public int Insert(User User)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "IN");
                int codigoUserInserido = _repository.Insert(User);
                Log.write(Log.Nivel.INFO, "OUT");
                return codigoUserInserido;
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel inserir.");
            }
            return 0;
        }

        public int Update(User User)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + User.codigo + " IN");
                _repository.Update(User);
                Log.write(Log.Nivel.INFO, "Codigo = " + User.codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + User.codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel alterar.");
            }

            return 0;
        }

        public int Delete(int codigo)
        {
            try
            {
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " IN");
                User user = _repository.SelectById(codigo);

                if (user == null)
                {
                    Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " Este cadastro não foi encontrado no banco de dados. OUT");
                    _notificationContext.AddNotification("Este cadastro não foi encontrado no banco de dados.");
                    return 0;
                }
                _repository.Delete(user);
                Log.write(Log.Nivel.INFO, "Codigo = " + codigo + " OUT");
            }
            catch (Exception ex)
            {
                Log.write(Log.Nivel.ERROR, ex, "Codigo = " + codigo + " OUT ERROR");
                _notificationContext.AddNotification("Não foi possivel deletar.");
            }

            return 0;
        }
    }
}
