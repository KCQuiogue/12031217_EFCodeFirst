using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCode_First.DataModel
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=csb-entpro.wongph.com;Initial Catalog=ENTRPOG_000012031217_EFCodeFirst;Persist Security Info=True;TrustServerCertificate=True;User ID=12031217;Password=uV8qD5oX");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().Property(p => p.Stock).HasDefaultValue(0);
            modelBuilder.Entity<CustomerOrder>().Property(p => p.OrderDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<ItemOrder>().Property(p => p.OrderDate).HasDefaultValueSql("getdate()");
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
    }
}
