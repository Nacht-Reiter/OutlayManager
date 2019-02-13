using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutlayManager.DataAccess.Models
{
    public class User : Model
    {
        String UId { get; set; }
        String FullName { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public int? AccountId { get; set; }

    }
}