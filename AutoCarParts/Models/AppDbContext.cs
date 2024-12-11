using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarParts.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           // optionsBuilder.UseSqlite(@"Server=localhost\SQLEXPRESS01;Database=eid;Trusted_Connection=True;TrustServerCertificate=True;");

            optionsBuilder.UseSqlite("Data Source=./LiteI.db");
        }
        public DbSet<Part> parts  { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Customer>  customers { get; set; }
        public DbSet<Inventory> inventories { get; set; }
        public DbSet<Order> orders  { get; set; }
        public DbSet<OrderDetail> ordersDetails { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Manufacturer> manufacturers { get; set; }


    }
}
