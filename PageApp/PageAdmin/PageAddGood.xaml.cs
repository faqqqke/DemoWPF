using DemoWPF.DataApp;
using DemoWPF.PageApp.PagesGoods;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DemoWPF.PageApp.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageAddGood.xaml
    /// </summary>
    public partial class PageAddGood : Page
    {
        private string fileName;
        public PageAddGood()
        {
            InitializeComponent();
            comboBoxProductCategory.ItemsSource = new List<String>()
            { "Амуниция и снаряжение", "Оснастка", "Приманки", "Леска", "Катушки" };
        }

        private void buttonAddImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPG Files (*.jpg)|*.jpg";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                fileName = dlg.FileName;
                textBoxImageName.Text = dlg.Title;
            }
        }

        private void buttonAddGood_Click(object sender, RoutedEventArgs e)
        {
            Product1 product1 = new Product1()
            {
                ProductArticleNumber = textBoxArticle.Text,
                ProductName = textBoxProductName.Text,
                ProductDescription = textBoxDescription.Text,
                ProductCategory = comboBoxProductCategory.SelectedItem.ToString(),
                ProductManufacturer = textBoxFactory.Text,
                ProductCost = Convert.ToDecimal(textBoxPrice.Text),
                ProductDiscountAmount = Convert.ToByte(textBoxAmount.Text),
                ProductQuantityInStock = Convert.ToByte(textBoxAmountInStock.Text)
            };

            FileCopy(textBoxArticle.Text);
            PageClass.connectDB.Product1.Add(product1);
            PageClass.connectDB.SaveChanges();
            MessageBox.Show("Операция прошла успешно");
        }

        private void FileCopy(string name)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(fileName, UriKind.RelativeOrAbsolute));
            string pathNewDir = $@"{PageListGoods.s}Resource\DefaultImage\{ name}.jpg";
            File.Copy(fileName, pathNewDir);
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            PageClass.frameObject.GoBack();
        }
    }
}
