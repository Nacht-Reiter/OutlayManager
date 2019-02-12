﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace OutlayManager.DataAccess.Models
{
    public class User : Model
    {
        int Id { get; set; }
        String UId { get; set; }
        String FullName { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public int? AccountId { get; set; }

    }
}