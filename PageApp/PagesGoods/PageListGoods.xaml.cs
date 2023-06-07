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
using DemoWPF.PageApp.PagesGoods;

namespace DemoWPF.PageApp.PagesGoods
{
    /// <summary>
    /// Логика взаимодействия для PageListGoods.xaml
    /// </summary>
    public partial class PageListGoods : Page
    {
        public List<Product1> lists = new List<Product1>();
        public int index = 0;
        public static string s = Environment.CurrentDirectory;

        public PageListGoods()
        {
            InitializeComponent();
            lists = PageClass.connectDB.Product1.ToList();
            FillingListBox(index);
            textBlockGoodsLeft.Text = $"{index + 1} из {lists.Count}";
            s = s.Remove(s.Length - 9);
            
        }

        public void FillingListBox(int index)
        {
            listBoxAboutGood.Items.Clear();
            listBoxAboutGood.Items.Add($"Наименование: {lists[index].ProductName}");
            listBoxAboutGood.Items.Add($"Описание товара: {lists[index].ProductDescription}");
            listBoxAboutGood.Items.Add($"Производитель: {lists[index].ProductManufacturer}");
            listBoxAboutGood.Items.Add($"Цена: {lists[index].ProductCost}");

            try
            {
                imageGood.Source = new BitmapImage(new Uri($@"{s}Resource\GoodsPhoto\{ lists[index].ProductArticleNumber }.jpg"));
            }
            catch (Exception)
            {
                imageGood.Source = new BitmapImage(new Uri($@"\Resource\DefaultImage\picture.png", UriKind.Relative));
            }
        }

        public void IndexUp()
        {
            if (index <= lists.Count - 2)
                ++index;
            else index = 0;
            textBlockGoodsLeft.Text = $"{index + 1} из {lists.Count}";
        }

        public void IndexDown()
        {
            if (index >= 1)
                --index;
            else index = lists.Count - 1;
            textBlockGoodsLeft.Text = $"{index + 1} из {lists.Count}";
        }

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                listBoxAboutGood.ItemsSource = PageClass.connectDB.Product1.Where(x => x.ProductName == textBoxSearch.Text).ToList();
                if (listBoxAboutGood != listBoxAboutGood.ItemsSource)
                    PageClass.frameObject.Navigate(new PageListGoods());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonLeft_Click(object sender, RoutedEventArgs e)
        {
            IndexDown();
            FillingListBox(index);
        }

        private void buttonRight_Click(object sender, RoutedEventArgs e)
        {
            IndexUp();
            FillingListBox(index);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageClass.frameObject.GoBack();
        }
    }
}
