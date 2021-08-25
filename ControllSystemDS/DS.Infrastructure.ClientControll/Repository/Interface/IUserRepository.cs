using System;
using System.Collections.Generic;
using System.Text;
using DS.Domain.ClientControll;

namespace DS.Infrastructure.ClientControll.Repository.Interface
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public User Get(string username, string password);

    }
}
