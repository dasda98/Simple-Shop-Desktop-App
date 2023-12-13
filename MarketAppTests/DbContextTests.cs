using System;
using System.Data;
using System.Windows;
using MarketApp.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace MarketAppTests
{
    public class DbContextTests : IDisposable
    {
        private readonly DatabaseContext _context;

        public DbContextTests()
        {

            _context = new DatabaseContext();
        }

        [Fact]
        public void CanConnectToDatabase()
        {
            // Act
            var connection = _context.Database.GetDbConnection();
            connection.Open();

            // Assert
            Assert.NotNull(connection);
            Assert.Equal(ConnectionState.Open, connection.State);

            connection.Close();
        }

        [Fact]
        public void CanGetAllElementsFromDatabase()
        {
            var customers = _context.Customers.ToList();
            var products = _context.Products.ToList();
            var order = _context.Orders.ToList();
            var order_items = _context.OrderItems.ToList();

            // Assert
            Assert.NotEmpty(customers);
            Assert.NotEmpty(products);
            Assert.NotEmpty(order);
            Assert.NotEmpty(order_items);

        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}