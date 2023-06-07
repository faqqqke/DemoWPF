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

namespace DemoWPF.PageApp
{
    /// <summary>
    /// Логика взаимодействия для PageAddUser.xaml
    /// </summary>
    public partial class PageAddUser : Page
    {
        public PageAddUser()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if(PageClass.connectDB.User1.Count(x => x.UserLogin == txbAddLoginUser.Text) > 0)
                {
                    MessageBox.Show("логин занят", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                } 

                User1 user = new User1();
                {
                    
                   user.UserLogin = txbAddLoginUser.Text;
                   user.UserPassword = txbAddPassUser.Text;
                   user.UserName = txbAddNameUser.Text;
                   user.UserSurname = txbAddSurUser.Text;
                   user.UserPatronymic = txbAddPatUser.Text;
                   user.UserRole = 3;
                };
                PageClass.connectDB.User1.Add(user);
                PageClass.connectDB.SaveChanges();
                MessageBox.Show("пользователь добавлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageClass.frameObject.GoBack();
        }
    }
}
