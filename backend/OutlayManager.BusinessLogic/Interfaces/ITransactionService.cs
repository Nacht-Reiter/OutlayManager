using OutlayManager.Common.DTOs;
using OutlayManager.DataAccess.Models;

namespace OutlayManager.BusinessLogic.Interfaces
{
    public interface ITransactionService : ICRUDService<Transaction, TransactionDTO>
    {
    }
}
