using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace application
{
    public partial class ProductsPage : Page
    {
        public ObservableCollection<Products_> Products { get; set; }

        public ProductsPage()
        {
            InitializeComponent();
            Products = new ObservableCollection<Products_>();
            ProductsList.ItemsSource = Products;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            if((!string.IsNullOrWhiteSpace(ProductNameTextBox.Text) && 
                int.TryParse(ProductNameTextBox.Text, out int _) == false) &&
              (!string.IsNullOrWhiteSpace(ProductPriceTextBox.Text) && 
              int.TryParse(ProductPriceTextBox.Text, out int n) == true))
            {
                using(ComputerShopEntities computerShopContext = new ComputerShopEntities())
                {
                    computerShopContext.Products_.Add(new Products_()
                    {
                        ProductName = ProductNameTextBox.Text,
                        ProductCost = n
                    });
                    computerShopContext.SaveChanges();
                }
            }
            else
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("Не удалось добавить продукт в базу данных")
                {
                    Owner = Application.Current.MainWindow
                };
                customMessageBox.ShowDialog();
            }
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedProduct = button?.CommandParameter as Products_;
            CustomProduct newProduct = new CustomProduct()
            {
                ID = selectedProduct.ID,
                ProductName = selectedProduct.ProductName,
                ProductCost = selectedProduct.ProductCost
            };
            EditWindow editProductWindow = new EditWindow(newProduct as IEntityEdit)
            {
                Owner = Application.Current.MainWindow
            };
            editProductWindow.Show();
        }
        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedProduct = button?.CommandParameter as Products_;
            if (selectedProduct != null)
            {
                using (ComputerShopEntities computerShopContext = new ComputerShopEntities())
                {
                    var productFromDb = computerShopContext.Products_.Find(selectedProduct.ID);
                    if (productFromDb != null)
                    {
                        computerShopContext.Products_.Remove(productFromDb);
                        computerShopContext.SaveChanges();
                    }
                }
                Products.Remove(selectedProduct);
            }
        }

        private void Field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source.Equals(ProductNameTextBox))
            {
                ProductNameFieldPlaceHolder.Visibility = Visibility.Hidden;
            }
            else if (e.Source.Equals(ProductPriceTextBox))
            {
                ProductPriceFieldPlaceHolder.Visibility = Visibility.Hidden;
            }
        } 

        private void Field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source.Equals(ProductNameTextBox) && string.IsNullOrWhiteSpace(ProductNameTextBox.Text))
            {
                ProductNameFieldPlaceHolder.Visibility = Visibility.Visible;
            }
            else if (e.Source.Equals(ProductPriceTextBox) && string.IsNullOrWhiteSpace(ProductPriceTextBox.Text))
            {
                ProductPriceFieldPlaceHolder.Visibility = Visibility.Visible;
            }
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (ComputerShopEntities computerShopContext = new ComputerShopEntities())
            {
                Products.Clear();
                var productsFromDb = computerShopContext.Products_.ToList();
                foreach (var product in productsFromDb)
                {
                    Products.Add(product);
                }
            }
        }

        private void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedProduct = button?.CommandParameter as Products_;
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
                    Baskets_Products baskets_Products = new Baskets_Products()
                    {
                        ProductID = selectedProduct.ID,
                        BasketID = userBasket.ID 
                    };


                    computerShopEntities.Baskets_.Add(userBasket);
                    computerShopEntities.Baskets_Products.Add(baskets_Products);


                    computerShopEntities.SaveChanges();
                    baskets_Products.BasketID = userBasket.ID;
                    computerShopEntities.SaveChanges();
                }
                else
                {
                    Baskets_Products baskets_Products = new Baskets_Products()
                    {
                        ProductID = selectedProduct.ID,
                        BasketID = userBasket.ID
                    };

                    computerShopEntities.Baskets_Products.Add(baskets_Products);
                    computerShopEntities.SaveChanges();
                }
            }
        }
    }
}
