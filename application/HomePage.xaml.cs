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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private string[] imageSources = new string[]
        {
            "Resources/images/homepageimage1.png",
            "Resources/images/homepageimage2.png",
            "Resources/images/homepageimage3.jpg"
        };

        private int currentImageIndex = 0;

        public HomePage()
        {
            InitializeComponent();
            UpdateImage();
            SetArrowVisibility();
        }

        private void UpdateImage()
        {
            MainImage.Source = new BitmapImage(new Uri(imageSources[currentImageIndex], UriKind.Relative));
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                UpdateImage();
            }
            SetArrowVisibility();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentImageIndex < imageSources.Length - 1)
            {
                currentImageIndex++;
                UpdateImage();
            }
            SetArrowVisibility();
        }

        private void SetArrowVisibility()
        {
            PrevButton.Visibility = currentImageIndex > 0 ? Visibility.Visible : Visibility.Collapsed;
            NextButton.Visibility = currentImageIndex < imageSources.Length - 1 ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ImageContainer_MouseEnter(object sender, MouseEventArgs e)
        {
            SetArrowVisibility();
        }

        private void ImageContainer_MouseLeave(object sender, MouseEventArgs e)
        {
            PrevButton.Visibility = Visibility.Collapsed;
            NextButton.Visibility = Visibility.Collapsed;
        }
    }
}
