using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int Count { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string Barcode { get; set; }
        [DefaultValue(0)]
        public int State { get; set; }
        [DefaultValue(1)]
        public int UserId { get; set; }
        public virtual User Users { get; set; }
    }
}