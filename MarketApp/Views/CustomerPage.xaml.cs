using MarketApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;


namespace MarketApp.Views
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {

        public CustomerPage()
        {
            InitializeComponent();

            DataContext = App.Current.Services.GetService<CustomerViewModel>();
        }
    }
}
