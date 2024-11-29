using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        ObservableCollection<IBasketElement> basketElements;
        public CartPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int currentBasketId = GetCurrentBasketId();

            using (ComputerShopEntities _context = new ComputerShopEntities())
            {
                basketElements = new ObservableCollection<IBasketElement>();

                var products = _context.Baskets_Products
                    .AsNoTracking()
                    .Where(bp => bp.BasketID == currentBasketId)
                    .Select(bp => new CustomBasketProducts
                    {
                        ID = bp.ID,
                        ElementID = bp.ProductID,
                        ElementName = bp.Products_.ProductName,
                        ElementPrice = bp.Products_.ProductCost,
                        ImagePath = bp.Products_.ImagePath
                    }).ToList();

                foreach (var product in products)
                {
                    basketElements.Add(product);
                }

                var services = _context.Baskets_Services
                    .AsNoTracking()
                    .Where(bs => bs.BasketID == currentBasketId)
                    .Select(bs => new CustomBasketServices
                    {
                        ID = bs.ID,
                        ElementID = bs.ServiceID,
                        ElementName = bs.Services_.ServiceName,
                        ElementPrice = bs.Services_.ServiceCost,
                        ImagePath = bs.Services_.ImagePath
                    }).ToList();

                foreach (var service in services)
                {
                    basketElements.Add(service);
                }

                BasketElementsList.ItemsSource = basketElements;
            }
        }

        private int GetCurrentBasketId()
        {
            using (ComputerShopEntities _context = new ComputerShopEntities())
            {
                var currentClient = _context.Clients_.FirstOrDefault(client => client.AccountID == CurrentUser.user.ID);

                var currentBasket = _context.Baskets_
                    .Where(basket => basket.ClientID == currentClient.ID)
                    .OrderByDescending(basket => basket.ID)
                    .FirstOrDefault();

                var currentOrder = _context.Orders_.FirstOrDefault(order => order.BasketID == currentBasket.ID);

                if (currentBasket != null && currentOrder == null)
                {
                    return currentBasket.ID;
                }
                else
                {
                    var newBasket = new Baskets_()
                    {
                        ClientID = currentClient.ID,                 
                    };
                    _context.Baskets_.Add(newBasket);
                    _context.SaveChanges();
                    return newBasket.ID;
                }
            }
        }

        private void RemoveFromBasket(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedBasketElement = button?.CommandParameter as IBasketElement;
            if (selectedBasketElement != null)
            {
                selectedBasketElement.RemoveFromBasket();
                basketElements.Remove(selectedBasketElement);
            }
        }

        private void MakeOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (basketElements.Count > 0)
            {
                using (ComputerShopEntities _context = new ComputerShopEntities())
                {
                    var currentClient = _context.Clients_.FirstOrDefault(client => client.AccountID == CurrentUser.user.ID);

                    var currentBasket = _context.Baskets_
                        .Where(basket => basket.ClientID == currentClient.ID)
                        .OrderByDescending(basket => basket.ID)
                        .FirstOrDefault();

                    if (currentBasket != null)
                    {
                        Orders_ newOrder = new Orders_()
                        {
                            BasketID = currentBasket.ID,
                            OrderStatus = true
                        };

                        _context.Orders_.Add(newOrder);
                        _context.SaveChanges();
                    }
                    else
                    {
                        CustomMessageBox customMessageBox = new CustomMessageBox("Корзина не найдена")
                        {
                            Owner = Application.Current.MainWindow
                        };
                        customMessageBox.Show();
                    }
                }
            }
            else
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("Добавьте что-то в корзину")
                {
                    Owner = Application.Current.MainWindow
                };
                customMessageBox.Show();
            }
        }
    }
}
