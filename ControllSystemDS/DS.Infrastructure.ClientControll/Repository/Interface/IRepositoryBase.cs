using System.Collections.Generic;
using DS.Domain.ClientControll;

namespace DS.Infrastructure.ClientControll.Repository.Interface
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        int Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> Get();
        TEntity SelectById(int codigo);
    }
}
