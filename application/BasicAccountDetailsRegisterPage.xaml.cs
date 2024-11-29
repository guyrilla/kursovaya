using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для BasicAccountDetailsRegisterPage.xaml
    /// </summary>
    public partial class BasicAccountDetailsRegisterPage : Page
    {
        private Window window;
        public BasicAccountDetailsRegisterPage()
        {
            InitializeComponent();
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            window = Window.GetWindow(this);
            if (window is MainWindow mainWindow)
            {
                CustomClient newClient = new CustomClient();
                newClient.SetRole();
                newClient.EnterBasicAccountDetails(EmailTextBox.Text, LoginTextBox.Text, PasswordTextBox.Password);
                if (FieldValidator.ValidateBasicAccountDetails(EmailTextBox.Text, LoginTextBox.Text, PasswordTextBox.Password) == true)
                {
                    mainWindow.NavigateToPage(new SecondaryAccountDetailsRegisterPage(newClient));
                }
                else
                {
                    CustomMessageBox customMessageBox = new CustomMessageBox("Неверные данные")
                    {
                        Owner = Application.Current.MainWindow
                    };
                    customMessageBox.ShowDialog();
                }
            }
            else if (window is HomeWindow homeWindow)
            {
                CustomMaster newMaster = new CustomMaster();
                newMaster.SetRole();
                newMaster.EnterBasicAccountDetails(EmailTextBox.Text, LoginTextBox.Text, PasswordTextBox.Password);
                if (FieldValidator.ValidateBasicAccountDetails(EmailTextBox.Text, LoginTextBox.Text, PasswordTextBox.Password) == true)
                {
                    homeWindow.NavigateToPage(new SecondaryAccountDetailsRegisterPage(newMaster));
                }
                else
                {
                    CustomMessageBox customMessageBox = new CustomMessageBox("Неверные данные")
                    {
                        Owner = Application.Current.MainWindow
                    };
                    customMessageBox.ShowDialog();
                }
            }
        }

        private void LoginButton_Click(object sender, MouseButtonEventArgs e)
        {
            window = Window.GetWindow(this);
            if(window is MainWindow mainWindow)
            {
                mainWindow.NavigateToPage(new LoginPage());
            }
        }
        private void Field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source.Equals(EmailTextBox))
            {
                EmailPlaceHolder.Visibility = Visibility.Hidden;
            }
            else if (e.Source.Equals(LoginTextBox))
            {
                LoginPlaceHolder.Visibility = Visibility.Hidden;
            }
            else if (e.Source.Equals(PasswordTextBox))
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
            else if (e.Source.Equals(LoginTextBox) && string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                LoginPlaceHolder.Visibility = Visibility.Visible;
            }
            else if (e.Source.Equals(PasswordTextBox) && string.IsNullOrWhiteSpace(PasswordTextBox.Password))
            {
                PasswordPlaceHolder.Visibility = Visibility.Visible;
            }
        }
    }
}
