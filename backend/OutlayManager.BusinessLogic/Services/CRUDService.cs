using AutoMapper;
using OutlayManager.BusinessLogic.Interfaces;
using OutlayManager.Common.DTOs;
using OutlayManager.DataAccess.Models;
using OutlayManager.DataAccess.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutlayManager.BusinessLogic.Services
{
    public class CRUDService<TModel, TDTO> : ICRUDService<TModel, TDTO> where TModel : Model where TDTO : BasicDTO
    {
        protected readonly IUnitOfWork uow;
        protected readonly IMapper mapper;

        public CRUDService(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }


        public virtual async Task<bool> AddAsync(TDTO item)
        {
            if (uow != null)
            {
                var result = await uow.Repository<TModel>().CreateAsync(mapper.Map<TModel>(item));
                if (result != null)
                {
                    await uow.SaveAsync();
                    return true;
                }
            }
            return false;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            if (uow != null)
            {
                var result = await uow.Repository<TModel>().DeleteAsync(id);
                if (result != null)
                {
                    await uow.SaveAsync();
                    return true;
                }
                
            }
            return false;
        }

        public virtual async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            if (uow != null)
            {
                var item = await uow.Repository<TModel>().GetAllAsync();
                if(item != null)
                {
                    return mapper.Map<IEnumerable<TDTO>>(item);
                }
            }
            return null;

                
        }

        public virtual async Task<TDTO> GetAsync(int id)
        {
            if (uow != null)
            {
                var items = await uow.Repository<TModel>().GetAsync(id);
                return mapper.Map<TDTO>(items);
            }
            return null;
        }

        public virtual async Task<TDTO> UpdateAsync(int id, TDTO item)
        {
            if (uow != null)
            {
                item.Id = id;
                var result = uow.Repository<TModel>().Update(mapper.Map<TModel>(item));
                if(result != null)
                {
                    await uow.SaveAsync();
                    return mapper.Map<TDTO>(result);
                }
            }
            return null;
        }
    }
}
