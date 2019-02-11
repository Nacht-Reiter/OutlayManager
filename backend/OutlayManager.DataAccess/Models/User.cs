using System;
using System.Collections.Generic;
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

        public IEnumerable<Category> Categories { get; set; }

        public User()
        {
            Categories = new List<Category>();
        }
    }
}