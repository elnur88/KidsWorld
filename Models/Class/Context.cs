using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KidsWorld.Models.Class
{
    public class Context:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<GoodsInfo> GoodsInfos { get; set; }
        public DbSet<GoodsPhoto> GoodsPhotos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }
    }
}