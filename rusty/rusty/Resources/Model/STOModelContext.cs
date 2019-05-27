using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace rusty.Resources.Model
{
    class STOModelContext : DbContext
    {
        public STOModelContext() : base("DefaultConnection")
        {

        }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}

