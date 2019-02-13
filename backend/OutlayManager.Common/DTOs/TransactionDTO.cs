using System;

namespace OutlayManager.Common.DTOs
{
    public class TransactionDTO
    {
        int Id { get; set; }
        public DateTime Time { get; set; }
        public decimal Value { get; set; }
        public bool IsIncome { get; set; }
        public CategoryDTO Category { get; set; }
        public AccountDTO Account { get; set; }
    }
}
