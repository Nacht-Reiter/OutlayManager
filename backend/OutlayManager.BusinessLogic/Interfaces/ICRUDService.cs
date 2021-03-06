﻿using OutlayManager.Common.DTOs;
using OutlayManager.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutlayManager.BusinessLogic.Interfaces
{
    public interface ICRUDService<TModel, TDTO> where TModel : Model where TDTO : BasicDTO
    {
        Task<TDTO> GetAsync(int id);
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<bool> AddAsync(TDTO item);
        Task<bool> DeleteAsync(int id);
        Task<TDTO> UpdateAsync(int id, TDTO item);
    }
}
