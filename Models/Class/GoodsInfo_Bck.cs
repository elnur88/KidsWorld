using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KidsWorld.Models.Class
{
    public class GoodsInfo_Bck
    {
        [Key]
        public int ID { get; set; }
        public int GoodsInfoId { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(20)]
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime RecordDate { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(200)]
        public string Description { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(10)]
        public string Size { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(10)]
        public string Color { get; set; }
        public int Count { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string Barcode { get; set; }

        public int CategoryId { get; set; }
        public int UserId { get; set; }

    }
}