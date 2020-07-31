using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KidsWorld.Models.Class
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public DateTime RecordDate { get; set; }
        public int Status { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(200)]
        public string Description { get; set; }
        public decimal Amount { get; set; }
        [DefaultValue(0)]
        public int State { get; set; }
        [DefaultValue(1)]
        public int UserId { get; set; }
        public virtual User Users { get; set; }
    }
}