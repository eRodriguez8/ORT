﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua_Inventario.Dal
{
    public class GenericRepository<TEntity, TDataBase> : IGenericRepository<TEntity, TDataBase> where TEntity : class where TDataBase : DbContext
    {
        internal DbSet<TEntity> dbSet { get; }

        internal TDataBase context;

        public GenericRepository(TDataBase context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null, bool trackeable = false,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!trackeable)
            {
                query = query.AsNoTracking();
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
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
            IQueryable<TEntity> query = dbSet;
            return query;
        }

        public virtual void Insert(TEntity entity)
        {
            
                context.Configuration.AutoDetectChangesEnabled = true;
            context.Configuration.ValidateOnSaveEnabled = true;
            dbSet.Add(entity);
        }

        public virtual void BulkInsert(List<TEntity> entity)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            dbSet.AddRange(entity);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}