using System;
using Microsoft.Data.Entity;
using System.Threading.Tasks;

namespace Atillion.Framework.Data.EntityFramework
{
    public class EFUow : IUow, IDisposable
    {

        protected DbContext _dbContext;

        
        public EFUow(IRepositoryProvider repositoryProvider, DbContext context)
        {
            _dbContext = context;
            repositoryProvider.DbContext = context;
            RepositoryProvider = repositoryProvider;

            // Do NOT enable proxied entities, else serialization fails
            //_dbContext.Configuration.ProxyCreationEnabled = true;

            // Load navigation properties explicitly (avoid serialization trouble)
            //_dbContext.Configuration.LazyLoadingEnabled = true;
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        protected T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        protected IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        public Task<int> CommitAsync()
        {
            //this.ApplyRules();
            return _dbContext.SaveChangesAsync();
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                }
            }
        }

    }
}
