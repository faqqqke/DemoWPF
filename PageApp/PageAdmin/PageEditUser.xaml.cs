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
    /// Логика взаимодействия для PageEditUser.xaml
    /// </summary>
    public partial class PageEditUser : Page
    {
        User1 user;
        private Button button;

        public PageEditUser(User1 user)
        {
            InitializeComponent();
            this.user = user;
            gridviewUsers.ItemsSource = PageClass.connectDB.User1.
                Where(x => x.UserID == user.UserID).
                ToList();
        }

        public PageEditUser(Button button)
        {
            this.button = button;
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
