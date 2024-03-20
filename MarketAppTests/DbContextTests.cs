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
    public class DbContextTests
    {
        private readonly DatabaseContext _context;
        private readonly ITestOutputHelper _testOutputHelper;

        public DbContextTests(ITestOutputHelper testOutputHelper)
        {
            _context = new DatabaseContext();
            _testOutputHelper = testOutputHelper;
        }

        [Fact(Skip = "NO NEEDED")]
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

        [Fact(Skip = "NO NEEDED")]
        public void CanGetAllElementsFromDatabase()
        {
            var customers = _context.Customers.ToList();
            var order = _context.Orders.ToList();
            var orderItems = _context.OrderItems.ToList();

            // Assert
            Assert.NotEmpty(customers);
            Assert.NotEmpty(order);
            Assert.NotEmpty(orderItems);
        }
        
        [Fact]
        public void CheckRelations()
        {
            var order = _context.Orders.Where(b => b.OrderId == 1).Include(b => b.OrderItems).ToList();
            _testOutputHelper.WriteLine("OrderItems: " + order[0].OrderItems.Count);

        }
    }
}