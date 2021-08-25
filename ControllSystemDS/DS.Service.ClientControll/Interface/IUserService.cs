using System.Collections.Generic;
using DS.Domain.ClientControll;

namespace DS.Service.ClientControll.Interface
{
    public interface IUserService
    {
        List<User> Get();
        User Get(User user);
        int Insert(User user);
        int Update(User user);
        int Delete(int codigo);
    }
}
