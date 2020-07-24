using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidsWorld.Models.Class
{
    public class GoodsPhoto
    {
        [Key]
        public int PhotoId { get; set; }
        public int SubId { get; set; }
        public string PhotoPath { get; set; }
    }
}