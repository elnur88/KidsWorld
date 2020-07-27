using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KidsWorld.Models.Class
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [DefaultValue(0)]
        public int Status { get; set; }
        public DateTime RecordDate { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(20)]
        public string Name { get; set; }
        [Column(TypeName = "NVarchar")]
        [StringLength(20)]
        public string SubCategoryName { get; set; }
        public int SubId { get; set; }
        public virtual User User { get; set; }
    }
}