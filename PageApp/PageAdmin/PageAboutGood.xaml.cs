using DemoWPF.DataApp;
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

namespace DemoWPF.PageApp.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageAboutGood.xaml
    /// </summary>
    public partial class PageAboutGood : Page
    {
        Product1 product;
        public PageAboutGood(Product1 product)
        {
            InitializeComponent();
            this.product = product;
            GridViewGoods.ItemsSource = PageClass.connectDB.Product1.
                Where(x => x.ProductArticleNumber == product.ProductArticleNumber).
                ToList();
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            PageClass.connectDB.SaveChanges();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PageClass.connectDB.Product1.Remove(product);
            MessageBox.Show($"Продукт {product.ProductName} был удален");

            PageClass.frameObject.GoBack();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageClass.frameObject.GoBack();
        }
            
    }
}
