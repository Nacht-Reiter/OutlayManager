﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OutlayManager.DataAccess.Models
{
    public class Account : Model
    {
        public decimal Balance { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
        public int? CurrencyId { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }


        public Account()
        {
            Categories = new List<Category>();
            Transactions = new List<Transaction>();
        }
    }
}
