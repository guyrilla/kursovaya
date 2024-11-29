using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace application
{
    public partial class OrdersLogPage : Page
    {
        public ObservableCollection<Orders_> Orders { get; set; }
        public ObservableCollection<IBasketElement> BasketElements { get; set; }
        public OrdersLogPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (ComputerShopEntities _context = new ComputerShopEntities())
            {
                var orderViewModels = new ObservableCollection<OrderViewModel>();

                var orders = _context.Orders_
                    .Include("Baskets_")
                    .Include("Baskets_.Clients_")
                    .ToList();

                foreach (var order in orders)
                {
                    var basketElements = _context.Baskets_
                        .Include("Baskets_Products")
                        .Include("Baskets_Services")
                        .FirstOrDefault(basket => basket.ID == order.BasketID);

                    var orderViewModel = new OrderViewModel(order);
                    if (basketElements != null)
                    {
                        foreach (var product in basketElements.Baskets_Products)
                        {
                            orderViewModel.BasketElements.Add(new CustomBasketProducts
                            {
                                ID = product.ID,
                                ElementID = product.Products_.ID,
                                ElementName = product.Products_.ProductName,
                                ElementPrice = product.Products_.ProductCost,
                                ImagePath = product.Products_.ImagePath
                            });
                        }
                        foreach (var service in basketElements.Baskets_Services)
                        {
                            orderViewModel.BasketElements.Add(new CustomBasketServices
                            {
                                ID = service.ID,
                                ElementID = service.Services_.ID,
                                ElementName = service.Services_.ServiceName,
                                ElementPrice = service.Services_.ServiceCost,
                                ImagePath = service.Services_.ImagePath
                            });
                        }
                    }

                    orderViewModels.Add(orderViewModel);
                }
                OrdersDataGrid.ItemsSource = orderViewModels;
            }
        }
    }
}