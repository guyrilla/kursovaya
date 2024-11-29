using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для SecondaryAccountDetailsRegisterPage.xaml
    /// </summary>
    public partial class SecondaryAccountDetailsRegisterPage : Page
    {
        private Window window;
        private IEntityRegister entityRegister;

        public SecondaryAccountDetailsRegisterPage(IEntityRegister entityRegister)
        {
            InitializeComponent();
            this.entityRegister = entityRegister;
            HideLoginButton();
        }
        private void HideLoginButton()
        {
            window = Window.GetWindow(this);
            if(window is HomeWindow homeWindow)
            {
                LoginTextBlock.Visibility = Visibility.Hidden;
            }
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            window = Window.GetWindow(this);
            if (window is MainWindow mainWindow)
            {
                entityRegister.EnterSecondaryAccountDetails(FirstNameTextBox.Text, LastNameTextBox.Text, MiddleNameTextBox.Text);
                if (FieldValidator.ValidateSecondaryAccountDetails(FirstNameTextBox.Text, LastNameTextBox.Text, MiddleNameTextBox.Text))
                {
                    entityRegister.EnterIntoDB();
                    mainWindow.NavigateToPage(new LoginPage());
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
            else if(window is HomeWindow homeWindow)
            {
                entityRegister.EnterSecondaryAccountDetails(FirstNameTextBox.Text, LastNameTextBox.Text, MiddleNameTextBox.Text);
                if (FieldValidator.ValidateSecondaryAccountDetails(FirstNameTextBox.Text, LastNameTextBox.Text, MiddleNameTextBox.Text))
                {
                    entityRegister.EnterIntoDB();
                    homeWindow.NavigateToPage(new HomePage());
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
            if (window is MainWindow mainWindow)
            {
                mainWindow.NavigateToPage(new LoginPage());
            }
            else if (window is HomeWindow homeWindow)
            {
                homeWindow.NavigateToPage(new HomePage());
            }
        }

        private void Field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source.Equals(FirstNameTextBox))
            {
                FirstNamePlaceholder.Visibility = Visibility.Hidden;
            }
            else if (e.Source.Equals(LastNameTextBox))
            {
                LastNamePlaceholder.Visibility = Visibility.Hidden;
            }
            else if (e.Source.Equals(MiddleNameTextBox))
            {
                SurNamePlaceholder.Visibility = Visibility.Hidden;
            }
        }

        private void Field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source.Equals(FirstNameTextBox))
            {
                FirstNamePlaceholder.Visibility = Visibility.Visible;
            }
            else if (e.Source.Equals(LastNameTextBox))
            {
                LastNamePlaceholder.Visibility = Visibility.Visible;
            }
            else if (e.Source.Equals(MiddleNameTextBox))
            {
                SurNamePlaceholder.Visibility = Visibility.Visible;
            }
        }
    }
}
