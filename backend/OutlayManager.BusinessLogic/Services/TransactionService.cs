using AutoMapper;
using OutlayManager.BusinessLogic.Interfaces;
using OutlayManager.Common.DTOs;
using OutlayManager.DataAccess.Models;
using OutlayManager.DataAccess.Repository;
using System;
using System.Threading.Tasks;

namespace OutlayManager.BusinessLogic.Services
{
    public class TransactionService : CRUDService<Transaction, TransactionDTO>, ITransactionService
    {
        private readonly IAccountService accountService;

        public TransactionService(IUnitOfWork uow, IMapper mapper, IAccountService accountService) : base(uow, mapper)
        {
            this.accountService = accountService;
        }

        public override async Task<bool> AddAsync(TransactionDTO item)
        {
            if(item != null)
            {
                item.Time = DateTime.Now;
                var account = item.Account;
                if (item.IsIncome)
                {
                    account.Balance += item.Value;
                }
                else
                {
                    account.Balance -= item.Value;
                }
                await uow.Repository<Account>().Update(mapper.Map<Account>(account));
                await uow.SaveAsync();

            }

            return await base.AddAsync(item);
        }
    }
}
