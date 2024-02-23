using System;
using System.Data;
using System.Windows;
using MarketApp.Context;
using MarketApp.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace MarketAppTests
{
    public class DbContextTests : IDisposable
    {
        private readonly DatabaseContext _context;
        private readonly ITestOutputHelper _testOutputHelper;

        public DbContextTests(ITestOutputHelper testOutputHelper)
        {
            _context = new DatabaseContext();
            _testOutputHelper = testOutputHelper;
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
            var order = _context.Orders.ToList();

            // Assert
            Assert.NotEmpty(customers);
            Assert.NotEmpty(order);

        }
        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public void CanGetOrdersByCustomer()
        {
            Customer customer = _context.Customers
                .Where(s => s.CustomerId == 1)
                .Include(x => x.Orders)
                .FirstOrDefault();

            foreach( Order o in customer.Orders )
            {
                _testOutputHelper.WriteLine(o.TotalAmount.ToString());
            }
            _context.SaveChanges();

            Assert.NotNull(customer.Orders.ToList());
        }
    }
}