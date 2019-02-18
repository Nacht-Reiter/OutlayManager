using AutoMapper;
using OutlayManager.BusinessLogic.Interfaces;
using OutlayManager.Common.DTOs;
using OutlayManager.DataAccess.Models;
using OutlayManager.DataAccess.Repository;

namespace OutlayManager.BusinessLogic.Services
{
    public class CurrencyService : CRUDService<Currency, CurrencyDTO>, ICurrencyService
    {
        public CurrencyService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }
    }
}
