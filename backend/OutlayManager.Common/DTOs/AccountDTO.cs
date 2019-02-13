using System.Collections.Generic;

namespace OutlayManager.Common.DTOs
{
    public class AccountDTO
    {
        int Id { get; set; }
        public decimal Balance { get; set; }
        public UserDTO User { get; set; }
        public CurrencyDTO Currency { get; set; }
        public int? CurrencyId { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<TransactionDTO> Transactions { get; set; }


        public AccountDTO()
        {
            Categories = new List<CategoryDTO>();
            Transactions = new List<TransactionDTO>();
        }
    }
}
