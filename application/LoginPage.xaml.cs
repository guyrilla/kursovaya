using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private MainWindow mainWindow;

        public LoginPage()
        {
            InitializeComponent();
            mainWindow = Application.Current.MainWindow as MainWindow;
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigateToPage(new BasicAccountDetailsRegisterPage());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox customMessageBox;
            if (!string.IsNullOrWhiteSpace(EmailTextBox.Text) && !string.IsNullOrWhiteSpace(PasswordBox.Password)){
                using (ComputerShopEntities computerShopEntities = new ComputerShopEntities())
                {
                    var account = computerShopEntities.Accounts_
                        .FirstOrDefault(a => a.Email == EmailTextBox.Text);

                    if (account != null)
                    {
                        byte[] hashedInputPassword = HashPassword(PasswordBox.Password);
                        if (account.Password.SequenceEqual(hashedInputPassword))
                        {
                            HomeWindow homeWindow = new HomeWindow();
                            homeWindow.Show();
                            CurrentUser.user = account;
                            mainWindow.Close();
                        }
                        else
                        {
                            customMessageBox = new CustomMessageBox("Неверный пароль")
                            {
                                Owner = Application.Current.MainWindow
                            };
                            customMessageBox.ShowDialog();
                        }
                    }
                    else
                    {
                        customMessageBox = new CustomMessageBox("Аккаунт не найден")
                        {
                            Owner = Application.Current.MainWindow
                        };
                        customMessageBox.ShowDialog();
                    }
                }
            }
            else
            {
                customMessageBox = new CustomMessageBox("Введите данные")
                {
                    Owner = Application.Current.MainWindow
                };
                customMessageBox.ShowDialog();
            }
        }

        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        private void Field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source.Equals(EmailTextBox))
            {
                EmailPlaceHolder.Visibility = Visibility.Hidden;
            }
            else if (e.Source.Equals(PasswordBox))
            {
                PasswordPlaceHolder.Visibility = Visibility.Hidden;
            }
        }

        private void Field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source.Equals(EmailTextBox) && string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                EmailPlaceHolder.Visibility = Visibility.Visible;
            }
            else if (e.Source.Equals(PasswordBox) && string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                PasswordPlaceHolder.Visibility = Visibility.Visible;
            }
        }
    }
}
