using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OutlayManager.DataAccess.Models
{
    public class Category : Model
    {
        String Name { get; set; }
        String ColorHex { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? UserId { get; set; }

    }
}
