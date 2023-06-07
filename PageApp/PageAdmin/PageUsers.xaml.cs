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
    /// Логика взаимодействия для PageUsers.xaml
    /// </summary>
    public partial class PageUsers : Page
    {
        public PageUsers()
        {
            InitializeComponent();
            gridviewUsers.ItemsSource = PageClass.connectDB.User1.ToList();
        }

        private void BtnEditRole_Click(object sender, RoutedEventArgs e)
        {
            PageClass.frameObject.Navigate(new PageEditUser(sender as Button).DataContext as User1);
        }
    }
}
