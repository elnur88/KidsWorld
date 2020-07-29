using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KidsWorld.Models.Class
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [DefaultValue(0)]
        public int Status { get; set; }
        public DateTime RecordDate { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(35)]
        public string FullName { get; set; }
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
        [Column(TypeName = "NVarchar")]
        [StringLength(20)]
        public string Password { get; set; }
    }
}