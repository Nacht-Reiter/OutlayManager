using System;
using System.Collections.Generic;

namespace OutlayManager.Common.DTOs
{
    public class CategoryDTO
    {
        int Id { get; set; }
        String Name { get; set; }
        String ColorHex { get; set; }
        public UserDTO Account { get; set; }
        public int? AccountId { get; set; }
        public IEnumerable<TransactionDTO> Transactions { get; set; }

        public CategoryDTO()
        {
            Transactions = new List<TransactionDTO>();
        }
    }
}
