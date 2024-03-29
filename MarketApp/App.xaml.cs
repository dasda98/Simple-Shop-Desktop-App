﻿using MarketApp.Context;
using MarketApp.Interfaces;
using MarketApp.Repositories;
using MarketApp.Services;
using MarketApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MarketApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<DatabaseContext>();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<CustomerViewModel>();

            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<OrderViewModel>();

            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IItemRepository, ItemRepository>();

            //services.AddTransient<OrderViewModel>();

            services.AddTransient<IOrderItemService, OrderItemService>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();

            //services.AddTransient<OrderViewModel>();

            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }

}
