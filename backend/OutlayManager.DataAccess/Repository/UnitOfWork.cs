using Microsoft.EntityFrameworkCore;
using OutlayManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutlayManager.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext dbContext;
        private Dictionary<Type, object> repoStorage ;

        public UnitOfWork(DbContext db)
        {
            dbContext = db;
            repoStorage = new Dictionary<Type, object>();
        }

        public IRepository<TModel> Repository<TModel>() where TModel : Model
        {
            var type = typeof(TModel);
            if (repoStorage.ContainsKey(type))
            {
                return repoStorage[type] as IRepository<TModel>;
            }
            var repoInstance = new Repository<TModel>(dbContext);
            repoStorage.Add(type, repoInstance);
            return repoInstance;
        }

        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

    }
}
