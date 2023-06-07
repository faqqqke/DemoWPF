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
    /// Логика взаимодействия для PageEditGoods.xaml
    /// </summary>
    public partial class PageEditGoods : Page
    {
        public PageEditGoods()
        {
            InitializeComponent();
            GridViewGoods.ItemsSource = PageClass.connectDB.Product1.ToList();
            comboBoxSort.ItemsSource = new List<string>() { "По возрастанию", "По убыванию" };
        }

        private void BtnSeeStudent_Click(object sender, RoutedEventArgs e)
        {
            PageClass.frameObject.Navigate(new PageAboutGood((sender as Button).DataContext as Product1));
        }

        private void comboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridViewGoods.ItemsSource = PageClass.connectDB.Product1.ToList().OrderBy(x => x.ProductCost).ToList();
        }
    }
}
