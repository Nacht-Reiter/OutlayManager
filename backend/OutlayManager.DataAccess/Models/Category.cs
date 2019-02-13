using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutlayManager.DataAccess.Models
{
    public class Category : Model
    {
        String Name { get; set; }
        String ColorHex { get; set; }

        [ForeignKey("AccountId")]
        public virtual User Account { get; set; }
        public int? AccountId { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }

        public Category()
        {
            Transactions = new List<Transaction>();
        }
    }
}
