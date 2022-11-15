using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCategory.Repository.Repository
{
    public interface IGenericRepository<TEntity>
    {
        List<TEntity> GetALL();
        TEntity GetById(string id);
        void Insert(TEntity TEntity);
        void Update(TEntity entity);
        bool DeleteById(string Id);
        void Delete(TEntity TEntity);

    }
}
