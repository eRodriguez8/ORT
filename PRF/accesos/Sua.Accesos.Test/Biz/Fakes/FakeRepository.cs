using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Sua.Accesos.Test.Biz.Fakes
{
    public class FakeRepository<TEntity, TDataBase> : IGenericRepository<TEntity, TDataBase> where TEntity : class where TDataBase : DbContext
        {
            public FakeRepository(IList<TEntity> entity)
            {
                Data = entity;
                AccessCounterGet = 0;
                AccessCounterQuery = 0;
                AccessCounterInsert = 0;
                AccessCounterUpdate = 0;
                AccessCounterDelete = 0;
            }

            public int AccessCounterGet { get; private set; }
            public int AccessCounterQuery { get; private set; }
            public int AccessCounterInsert { get; private set; }
            public int AccessCounterUpdate { get; private set; }
            public int AccessCounterDelete { get; private set; }

            public IList<TEntity> Data { get; private set; }

            public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
            {
                AccessCounterGet++;

                var query = Data.AsQueryable();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties?.Split
                    (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query);
                }
                else
                {
                    return query;
                }
            }

            public virtual IQueryable<TEntity> Query()
            {
                AccessCounterQuery++;

                IQueryable<TEntity> query = Data.AsQueryable();
                return query;
            }

            public void Insert(TEntity entity)
            {
                AccessCounterInsert++;

                Data.Add(entity);
            }

            public void Update(TEntity entityToUpdate)
            {
                AccessCounterUpdate++;


            }

            public void Delete(TEntity entityToDelete)
            {
                AccessCounterDelete++;

                Data.Remove(entityToDelete);
            }
        }
    }
