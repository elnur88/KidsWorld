using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KidsWorld.Models.Class
{
    public class Sale_Bck
    {
        [Key]
        public int Id { get; set; }
        public int SaleId { get; set; }
        public DateTime RecordDate { get; set; }
        public int Status { get; set; }
        public decimal TotalPrice { get; set; }
        public int FakturaId { get; set; }
        public int Count { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string Barcode { get; set; }
        public int UserId { get; set; }
    }
}