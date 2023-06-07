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
using DemoWPF.DataApp;
using DemoWPF.PageApp.PagesGoods;



namespace DemoWPF.PageApp.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageChoose.xaml
    /// </summary>
    public partial class PageChoose : Page
    {
        public PageChoose()
        {
            InitializeComponent();
        }

        private void btnGoodsRedact_Click(object sender, RoutedEventArgs e)
        {
            PageClass.frameObject.Navigate(new PageEditGoods());
        }

        private void btnGoodsAdd_Click(object sender, RoutedEventArgs e)
        {
            PageClass.frameObject.Navigate(new PageAddGood());
        }

        private void btnListGoods_Click(object sender, RoutedEventArgs e)
        {
            PageClass.frameObject.Navigate(new PageListGoods());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageClass.frameObject.GoBack();
        }

        private void btnRework_Click(object sender, RoutedEventArgs e)
        {
            PageClass.frameObject.Navigate(new PageUsers());
        }
    }
}
