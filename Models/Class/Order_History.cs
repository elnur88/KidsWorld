using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KidsWorld.Models.Class
{
    public class Order_History
    {
        [Key]
        public int ID { get; set; }
        public int OrderId { get; set; }
        public int FakturaId { get; set; }
        [DefaultValue(0)]
        public int Status { get; set; }
        public DateTime RecordDate { get; set; }
        public int Count { get; set; }
        public decimal SalePrice { get; set; }
        public decimal TotalPrice { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(20)]
        public string City { get; set; }
        public int ZipCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(12)]
        public string Phone { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(100)]
        public string Adress { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Email { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string Barcode { get; set; }
        public int UserId { get; set; }

    }
}