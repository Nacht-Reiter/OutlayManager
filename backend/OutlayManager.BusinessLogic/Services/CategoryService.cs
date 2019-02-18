using AutoMapper;
using OutlayManager.BusinessLogic.Interfaces;
using OutlayManager.Common.DTOs;
using OutlayManager.DataAccess.Models;
using OutlayManager.DataAccess.Repository;

namespace OutlayManager.BusinessLogic.Services
{
    public class CategoryService : CRUDService<Category, CategoryDTO>, ICategoryService
    {
        public CategoryService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }
    }
}
