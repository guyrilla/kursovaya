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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace application
{
    /// <summary>
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        IEntityEdit entityForEdit;
        public EditWindow(IEntityEdit entityForEdit)
        {
            InitializeComponent();
            this.entityForEdit = entityForEdit;
            if(entityForEdit is IMasterEdit masterEdit)
            {
                ConfigureUI();
            }
        }
        private void ConfigureUI()
        {
            this.Background = new RadialGradientBrush(Color.FromRgb(83, 67, 84), Color.FromRgb(28, 23, 28));
            this.AllowsTransparency = true;
            this.WindowStyle = WindowStyle.None;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            StackPanel mainStackPanel = new StackPanel();
            AddTextBlock(mainStackPanel, "Имя");
            TextBox nameTextBox = AddTextBox(mainStackPanel, "NameTextBox");
            nameTextBox.TextChanged += StringTextBox_Changed;
            AddTextBlock(mainStackPanel, "Фамилия");
            TextBox secondNameTextBox = AddTextBox(mainStackPanel, "SecondNameTextBox");
            secondNameTextBox.TextChanged += StringTextBox_Changed;
            AddTextBlock(mainStackPanel, "Отчество");
            TextBox surNameTextBox = AddTextBox(mainStackPanel, "SurNameTextBox");
            surNameTextBox.TextChanged += StringTextBox_Changed;
            AddTextBlock(mainStackPanel, "Стаж работы");
            TextBox workExperienceTextBox = AddTextBox(mainStackPanel, "WorkExperienceTextBox");
            workExperienceTextBox.TextChanged += NumberTextBox_Changed;
            AddTextBlock(mainStackPanel, "Изображение");
            StackPanel imageStackPanel = new StackPanel { Orientation = Orientation.Horizontal };
            Image image = new Image { Width = 100, Height = 100, Margin = new Thickness(0, 0, 10, 0) };
            Button loadImageButton = new Button { Content = "Загрузить изображение", Foreground = Brushes.White, Background = new SolidColorBrush(Color.FromRgb(44, 42, 44)) };
            loadImageButton.Click += LoadImageButton_Click;
            Button removeImageButton = new Button { Content = "Удалить изображение", Foreground = Brushes.White, Background = new SolidColorBrush(Color.FromRgb(44, 42, 44)), Margin = new Thickness(5, 0, 0, 0) };
            removeImageButton.Click += RemoveImageButton_Click;
            imageStackPanel.Children.Add(image);
            imageStackPanel.Children.Add(loadImageButton);
            imageStackPanel.Children.Add(removeImageButton);
            mainStackPanel.Children.Add(imageStackPanel);
            StackPanel buttonPanel = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 10, 0, 0) };
            Button saveButton = new Button { Content = "Сохранить", Foreground = Brushes.White, Background = new SolidColorBrush(Color.FromRgb(255, 106, 0)) };
            saveButton.Click += SaveButton_Click;
            Button cancelButton = new Button { Content = "Выйти", Foreground = Brushes.White, Background = new SolidColorBrush(Color.FromRgb(255, 106, 0)), Margin = new Thickness(5, 0, 0, 0) };
            cancelButton.Click += CancelButton_Click;
            buttonPanel.Children.Add(saveButton);
            buttonPanel.Children.Add(cancelButton);
            mainStackPanel.Children.Add(buttonPanel);
            this.Content = mainStackPanel;
        }

        private void AddTextBlock(StackPanel panel, string text)
        {
            TextBlock textBlock = new TextBlock { Text = text, Foreground = Brushes.White };
            panel.Children.Add(textBlock);
        }

        private TextBox AddTextBox(StackPanel panel, string name)
        {
            TextBox textBox = new TextBox { Name = name, Background = new SolidColorBrush(Color.FromRgb(44, 42, 44)), Foreground = Brushes.White };
            panel.Children.Add(textBox);
            return textBox;
        }
        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                entityForEdit.EditImage(imagePath);
            }
        }

        private void RemoveImageButton_Click(object sender, RoutedEventArgs e)
        {
            entityForEdit.EditImage("");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            entityForEdit.SaveEntity(new ComputerShopEntities());
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StringTextBox_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!string.IsNullOrWhiteSpace(textBox.Text) && ConsistsOfSymbols(textBox) == true)
            {
                entityForEdit.EditName(textBox.Text);
                textBox.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2c2a2c");
            }
            else if(ConsistsOfSymbols(textBox) == false)
            {
                textBox.Background = Brushes.Red;
            }
            else
            {
                textBox.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2c2a2c");
            }
        }
        private bool ConsistsOfSymbols(TextBox textBox)
        {
            return textBox.Text.All(n => int.TryParse(n.ToString(), out _) == false) ? true : false;
        }

        private bool ConsistsOfNumbers(TextBox textBox)
        {
            return textBox.Text.All(n => int.TryParse(n.ToString(), out _) == true) ? true : false;
        }

        private void NumberTextBox_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!string.IsNullOrWhiteSpace(textBox.Text) && ConsistsOfNumbers(textBox) == true)
            {
                if(entityForEdit is IPriceableEntityEdit priceable)
                {
                    priceable.EditCost(int.Parse(textBox.Text));
                }
                else if(entityForEdit is IMasterEdit master)
                {
                    master.EditWorkExperience(byte.Parse(textBox.Text));
                }
                textBox.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2c2a2c");
            }
            else if (ConsistsOfNumbers(textBox) == false)
            {
                textBox.Background = Brushes.Red;
            }
            else
            {
                textBox.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2c2a2c");
            }
        }
    }
}
