using OutlayManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManager.DataAccess.Repository
{
    public interface IRepository<TModel> where TModel : Model
    {
        Task<TModel> CreateAsync(TModel entity);

        Task<TModel> Update(TModel entity);

        Task<TModel> DeleteAsync(int id);

        Task<List<TModel>> GetAllAsync();

        Task<TModel> GetAsync(int id);
    }
}
