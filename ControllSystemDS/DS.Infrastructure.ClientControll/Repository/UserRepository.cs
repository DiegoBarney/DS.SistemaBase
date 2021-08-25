using System.Linq;
using DS.Domain.ClientControll;
using DS.Infrastructure.ClientControll.Repository.Interface;
using DS.Infrastructure.ClientControll.Repository.Config;

namespace DS.Infrastructure.ClientControll.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public UserRepository(ApplicationDBContext context) : base(context)
        {
        }

        public User Get(string username, string password)
        {
            User user = context.Set<User>().Where(x => x.username.ToLower() == username.ToLower() && x.password == password).FirstOrDefault();
            return user;
        }
    }
}
