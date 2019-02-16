using OutlayManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManager.BusinessLogic.Interfaces
{
    public interface ICRUDService<TModel, TDTO> where TModel : Model where TDTO : class
    {
        Task<TDTO> GetAsync(int id);
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<bool> AddAsync(TDTO item);
        Task<bool> DeleteAsync(int id);
        Task<TDTO> Update(TDTO item);
    }
}
