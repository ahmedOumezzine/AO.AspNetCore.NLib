using AO.AspNetCore.NLib.ContextFactory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AO.AspNetCore.NLib
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext dbContext;

        /// <summary>
        /// NOTE: repository getters instantiate repositories as needed (lazily)...
        ///       i wish I knew of IoC "way" of wiring up repository getters...
        /// </summary>
        /// <param name="dbContextFactory"></param>
        public UnitOfWork(IDbContextFactory dbContextFactory)
        {
            dbContext = dbContextFactory.GetDbContext();
        }

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }
            IGenericRepository<T> repo = new GenericRepository<T>(dbContext);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public IGenericRepository<TEntity> GetNonGenericRepository<TEntity, TRepository>() where TEntity : class
        {
            if (this.repositories.Keys.Contains(typeof(TRepository)))
            {
                return this.repositories[typeof(TRepository)] as IGenericRepository<TEntity>;
            }
            var repoType = typeof(TRepository);
            var constructorInfo = repoType.GetConstructor(new Type[] { typeof(DbContext) });
            IGenericRepository<TEntity> repository = (IGenericRepository<TEntity>)constructorInfo.Invoke(new object[] { this.dbContext });
            this.repositories.Add(typeof(TRepository), repository);
            return repository;
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ///  dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}