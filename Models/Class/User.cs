using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KidsWorld.Models.Class
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public DateTime RecordDate { get; set; }
        public int Status { get; set; }
        public int User_Id { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(50)]
        public string FullName { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(100)]
        public string FullAdress { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(15)]
        public string UserName { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Password { get; set; }
        public int Role { get; set; }
        public ICollection<GoodsInfo> GoodsInfos { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}