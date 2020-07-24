using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KidsWorld.Models.Class
{
    public class Goods
    {
        [Key]
        public int GoodsId { get; set; }
        public int Count { get; set; }
        public decimal SalePrice { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string Barcode { get; set; }
    }
}