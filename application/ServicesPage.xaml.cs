using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace application
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        private ObservableCollection<Services_> Services { get; set; }
        public ServicesPage()
        {
            InitializeComponent();
            Services = new ObservableCollection<Services_>();
            ServicesList.ItemsSource = Services;
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(ServiceNameTextBox.Text) &&
                int.TryParse(ServiceNameTextBox.Text, out int _) == false) &&
              (!string.IsNullOrWhiteSpace(ServicePriceTextBox.Text) &&
              int.TryParse(ServicePriceTextBox.Text, out int n) == true))
            {
                using (ComputerShopEntities computerShopContext = new ComputerShopEntities())
                {
                    computerShopContext.Services_.Add(new Services_()
                    {
                        ServiceName = ServiceNameTextBox.Text,
                        ServiceCost = n
                    });
                    computerShopContext.SaveChanges();
                }
            }
            else
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("Не удалось добавить услугу в базу данных")
                {
                    Owner = Application.Current.MainWindow
                };
                customMessageBox.ShowDialog();
            }
        }

        private void EditServiceButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedService = button?.CommandParameter as Services_;
            CustomService newService = new CustomService()
            {
                ID = selectedService.ID,
                ServiceName = selectedService.ServiceName,
                ServiceCost = selectedService.ServiceCost
            };
            EditWindow editProductWindow = new EditWindow(newService as IEntityEdit)
            {
                Owner = Application.Current.MainWindow
            };
            editProductWindow.Show();
        }

        private void DeleteServiceButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedService = button?.CommandParameter as Services_;
            if (selectedService != null)
            {
                using (ComputerShopEntities computerShopContext = new ComputerShopEntities())
                {
                    var serviceFromDb = computerShopContext.Services_.Find(selectedService.ID);
                    if (serviceFromDb != null)
                    {
                        computerShopContext.Services_.Remove(serviceFromDb);
                        computerShopContext.SaveChanges();
                    }
                }
                Services.Remove(selectedService);
            }
        }

        private void Field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source.Equals(ServiceNameTextBox))
            {
                ServiceNameFieldPlaceHolder.Visibility = Visibility.Hidden;
            }
            else if (e.Source.Equals(ServicePriceTextBox))
            {
                ServicePriceFieldPlaceHolder.Visibility = Visibility.Hidden;
            }
        }

        private void Field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source.Equals(ServiceNameTextBox) && string.IsNullOrWhiteSpace(ServiceNameTextBox.Text))
            {
                ServiceNameFieldPlaceHolder.Visibility = Visibility.Visible;
            }
            else if (e.Source.Equals(ServicePriceTextBox) && string.IsNullOrWhiteSpace(ServicePriceTextBox.Text))
            {
                ServicePriceFieldPlaceHolder.Visibility = Visibility.Visible;
            }
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            LoadServices();
        }

        private void LoadServices()
        {
            using (ComputerShopEntities computerShopContext = new ComputerShopEntities())
            {
                Services.Clear();
                var servicesFromDb = computerShopContext.Services_.ToList();
                foreach (var service in servicesFromDb)
                {
                    Services.Add(service);
                }
            }
        }

        private void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedService = button?.CommandParameter as Services_;
            using (ComputerShopEntities computerShopEntities = new ComputerShopEntities())
            {

                Clients_ currentClient = computerShopEntities.Clients_.FirstOrDefault(client => client.AccountID == CurrentUser.user.ID);

                Baskets_ userBasket = computerShopEntities.Baskets_
                    .Where(basket => basket.ClientID == currentClient.ID)
                    .OrderByDescending(basket => basket.ID)
                    .FirstOrDefault();

                if (userBasket == null)
                {
                    userBasket = new Baskets_()
                    {
                        ClientID = currentClient.ID,
                    };
                    Baskets_Services baskets_Services = new Baskets_Services()
                    {
                        ServiceID = selectedService.ID,
                        BasketID = userBasket.ID
                    };


                    computerShopEntities.Baskets_.Add(userBasket);
                    computerShopEntities.Baskets_Services.Add(baskets_Services);


                    computerShopEntities.SaveChanges();
                    baskets_Services.BasketID = userBasket.ID;
                    computerShopEntities.SaveChanges();
                }
                else
                {
                    Baskets_Services baskets_Services = new Baskets_Services()
                    {
                        ServiceID = selectedService.ID,
                        BasketID = userBasket.ID
                    };

                    computerShopEntities.Baskets_Services.Add(baskets_Services);
                    computerShopEntities.SaveChanges();
                }
            }
        }
    }
}
