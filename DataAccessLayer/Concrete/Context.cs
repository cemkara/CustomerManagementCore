using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=CustomerManagementCore;trusted_connection=true;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<EmployeType> EmployeTypes { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
