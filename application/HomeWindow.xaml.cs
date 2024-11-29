using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace application
{
    /// <summary>
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            NavigateToPage(new HomePage());
        }

        public void NavigateToPage(Page page)
        {
            MainFrame.Navigate(page);
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage());
        }

        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ServicesPage());
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsPage());
        }

        private void MastersButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MastersPage());
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CartPage());
        }

        private void PersonalAccountButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrdersLogPage());
        }
    }
}
