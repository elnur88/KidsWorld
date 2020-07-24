using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidsWorld.Models.Class
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public DateTime RecordDate { get; set; }
        public int Status { get; set; }
        public decimal TotalPrice { get; set; }
        public int FakturaId { get; set; }
        public virtual User Users { get; set; }
    }
}