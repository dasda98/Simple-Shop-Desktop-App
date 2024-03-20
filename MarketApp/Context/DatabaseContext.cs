using MarketApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace MarketApp.Context
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

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

            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(e => e.Order)
                .WithMany(p => p.OrderItems);
            modelBuilder.Entity<OrderItem>()
                .HasOne<Item>(e => e.Item)
                .WithMany(p => p.OrderItems);

            Customer customer1 = new Customer {
                CustomerId = 1,
                FirstName = "Jakub",
                LastName = "Test",
                Email = "test@test.pl",
                PhoneNumber = "123456789"
            };
            Customer customer2 = new Customer
            {
                CustomerId = 2,
                FirstName = "Kacper",
                LastName = "Boner",
                Email = "boner@boner.pl",
                PhoneNumber = "987654321"
            };

            Order order1 = new Order { OrderId = 1, OrderDate = DateTime.UtcNow, TotalAmount = 270.0f, CustomerId = 1 };
            Order order2 = new Order { OrderId = 2, OrderDate = DateTime.UtcNow, TotalAmount = 300.0f, CustomerId = 1 };
            Order order3 = new Order { OrderId = 3, OrderDate = DateTime.UtcNow, TotalAmount = 100.0f, CustomerId = 2 };

            Item item1 = new Item { ItemId = 1, ItemName = "Keyboard", UnitPrice = 35.0f };
            Item item2 = new Item { ItemId = 2, ItemName = "Mouse", UnitPrice = 100.0f };

            OrderItem orderItem1 = new OrderItem { OrderItemId = 1, OrderId = 1, ItemId = 1,  Quantity = 2};
            OrderItem orderItem2 = new OrderItem { OrderItemId = 2, OrderId = 1, ItemId = 2,  Quantity = 2};
            OrderItem orderItem3 = new OrderItem { OrderItemId = 3, OrderId = 2, ItemId = 2,  Quantity = 3};
            OrderItem orderItem4 = new OrderItem { OrderItemId = 4, OrderId = 3, ItemId = 2,  Quantity = 1};

            List<Order> orders = [order1, order2, order3];
            List<Customer> customers = [customer1, customer2];
            List<Item> items = [item1, item2];
            List<OrderItem> ordersItems = [orderItem1, orderItem2, orderItem3, orderItem4];

            modelBuilder.Entity<Customer>().HasData(customers);
            modelBuilder.Entity<Item>().HasData(items);
            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<OrderItem>().HasData(ordersItems);
        }
    }
}
