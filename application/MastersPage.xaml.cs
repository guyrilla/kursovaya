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
    /// Логика взаимодействия для MastersPage.xaml
    /// </summary>
    public partial class MastersPage : Page
    {
        ObservableCollection<Masters_> Masters;
        HomeWindow currentWindow;
        public MastersPage()
        {
            InitializeComponent();
            Masters = new ObservableCollection<Masters_>();
            LoadMasters();
            MastersList.ItemsSource = Masters;
            
        }
        private void LoadMasters()
        {
            using (var computerShopEntities = new ComputerShopEntities())
            {
                var masters = computerShopEntities.Masters_
                    .Include("Masters_Services.Services_")
                    .ToList();

                foreach (var master in masters)
                {
                    Masters.Add(master);
                }
            }
        }

        private void AddMasterButton_Click(object sender, RoutedEventArgs e)
        {
            currentWindow = Window.GetWindow(this) as HomeWindow;
            BasicAccountDetailsRegisterPage basicAccountDetailsRegisterPage = new BasicAccountDetailsRegisterPage();
            basicAccountDetailsRegisterPage.LoginTextBlock.Visibility = Visibility.Hidden;
            currentWindow.NavigateToPage(basicAccountDetailsRegisterPage);

        }

        private void EditMasterButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedMaster = button?.CommandParameter as Masters_;
            CustomMaster customMaster = new CustomMaster()
            {
                ID = selectedMaster.ID,
                FirstName = selectedMaster.FirstName,
                SecondName = selectedMaster.SecondName,
                SurName = selectedMaster.SurName
            };
            EditWindow editWindow = new EditWindow(customMaster)
            {
                Owner = Application.Current.MainWindow
            };
            editWindow.Show();
        }

        private void RemoveMasterButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedMaster = button?.CommandParameter as Masters_;
            if (selectedMaster != null)
            {
                using (ComputerShopEntities computerShopContext = new ComputerShopEntities())
                {
                    var masterFromDb = computerShopContext.Masters_.FirstOrDefault(m => m.ID == selectedMaster.ID);
                    var masterAccount = computerShopContext.Accounts_.FirstOrDefault(acc => acc.ID == selectedMaster.AccountID);
                    if (masterFromDb != null)
                    {
                        computerShopContext.Masters_.Remove(masterFromDb);
                        computerShopContext.Accounts_.Remove(masterAccount);
                        computerShopContext.SaveChanges(); 
                    }
                    Masters.Remove(selectedMaster);
                }
            }
        }
    }
}
