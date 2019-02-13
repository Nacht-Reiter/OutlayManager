using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutlayManager.DataAccess.Models
{
    public class Transaction : Model
    {
        public DateTime Time { get; set; }

        public decimal Value { get; set; }

        public bool IsIncome { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int? CategoryId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public int? AccountId { get; set; }
    }
}
