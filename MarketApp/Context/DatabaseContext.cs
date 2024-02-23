using MarketApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace MarketApp.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("MyPostgresConnection");

                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("test");
            modelBuilder.Entity<Order>()
                .HasOne(e => e.Customer)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            Customer customer = new Customer { 
                CustomerId = 1, 
                FirstName = "Jakub", LastName = "Wojniak",  Email = "test@test.pl", 
                PhoneNumber = "123456789"
            };

            Order order1 = new Order { OrderId = 1, OrderDate = DateTime.UtcNow, TotalAmount = 123.12f, CustomerId = 1};
            Order order2 = new Order { OrderId = 2, OrderDate = DateTime.UtcNow, TotalAmount = 33.76f, CustomerId = 1};
            Order order3 = new Order { OrderId = 3, OrderDate = DateTime.UtcNow, TotalAmount = 45.45f, CustomerId = 1};

            List<Order> orders = new List<Order>();
            orders.Add(order1);
            orders.Add(order2);
            orders.Add(order3);

            modelBuilder.Entity<Customer>().HasData(customer);
            modelBuilder.Entity<Order>().HasData(orders);
        }
    }
}
