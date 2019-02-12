using Microsoft.EntityFrameworkCore;
using OutlayManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManager.DataAccess.Repository
{
    public class Repository<TModel> : IRepository<TModel> where TModel : Model
    {
        protected DbContext context;
        protected DbSet<TModel> DbSet;

        public Repository(DbContext c)
        {
            this.context = c;
            DbSet = context.Set<TModel>();
        }

        public async Task<TModel> CreateAsync(TModel entity)
        {
            return (await DbSet.AddAsync(entity)).Entity;
        }

        public async Task<TModel> DeleteAsync(int id)
        {
            TModel entity = await DbSet.FindAsync(id);
            if(entity != null)
            {
                return DbSet.Remove(entity).Entity;
            }
            return null;
        }

        public async Task<List<TModel>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TModel> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<TModel> Update(TModel entity)
        {
            return DbSet.Update(entity).Entity;
        }
    }
}
