using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua_Inventario.Dal
{
    public interface IGenericRepository<TEntity, TDataBase>
        where TEntity : class
        where TDataBase : DbContext
    {
        void Delete(TEntity entityToDelete);
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null, bool trackeable = false,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        void Insert(TEntity entity);
        void BulkInsert(List<TEntity> entity);
        IQueryable<TEntity> Query();
        void Update(TEntity entityToUpdate);
    }
}
