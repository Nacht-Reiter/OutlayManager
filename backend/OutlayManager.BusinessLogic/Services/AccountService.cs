using AutoMapper;
using OutlayManager.BusinessLogic.Interfaces;
using OutlayManager.Common.DTOs;
using OutlayManager.DataAccess.Models;
using OutlayManager.DataAccess.Repository;

namespace OutlayManager.BusinessLogic.Services
{
    public class AccountService : CRUDService<Account, AccountDTO>, IAccountService
    {
        public AccountService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }
    }
}
