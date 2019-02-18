using AutoMapper;
using OutlayManager.BusinessLogic.Interfaces;
using OutlayManager.DataAccess.Models;
using OutlayManager.DataAccess.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutlayManager.BusinessLogic.Services
{
    public class CRUDService<TModel, TDTO> : ICRUDService<TModel, TDTO> where TModel : Model where TDTO : class
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
                await uow.Repository<TModel>().CreateAsync(mapper.Map<TModel>(item));
                return true;
            }
            return false;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            if (uow != null)
            {
                await uow.Repository<TModel>().DeleteAsync(id);
                return true;
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

        public virtual async Task<TDTO> Update(TDTO item)
        {
            if (uow != null)
            {
                var items = uow.Repository<TModel>().Update(mapper.Map<TModel>(item));
                return mapper.Map<TDTO>(items);
            }
            return null;
        }
    }
}
