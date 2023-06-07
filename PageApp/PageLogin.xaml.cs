using DemoWPF.DataApp;
using DemoWPF.PageApp.PageAdmin;
using DemoWPF.PageApp.PagesGoods;
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
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        TextBlock userName;
        public PageLogin(TextBlock textBlock)
        {
            InitializeComponent();
            userName = textBlock;
            textBoxPassword.Visibility = Visibility.Hidden;
            passwordBoxPass.Visibility = Visibility.Visible;
        }
        //public void BetweenNumber(int firstNum)
        //{ }

        //public void CheckDate()
        //{
        //    int hour = DateTime.Now.Hour;
        //    if (BetweenNumber(hour) == DateTime.Now.Hour)
        //        textBlockHello.Text = "доброе утро";


                
            
        //}
        
        
        private User1 CheckUser() => PageClass.connectDB.User1.FirstOrDefault(t => t.UserLogin == textBoxLogin.Text
               && (t.UserPassword == passwordBoxPass.Password
               || textBoxPassword.Text == t.UserPassword));
        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            var user1 = CheckUser();
            if (user1 != null)
            {
                userName.Text = $"{user1.UserSurname} {user1.UserName} {user1.UserPatronymic}";
                if (user1.UserRole == 3)
                    PageClass.frameObject.Navigate(new PageListGoods());
                else
                    PageClass.frameObject.Navigate(new PageChoose());
            }
        }

        private void buttonGuest_Click(object sender, RoutedEventArgs e)
        {
            userName.Text = "Гость";
            PageClass.frameObject.Navigate(new PageListGoods());
        }

        private void checkBoxHidePass_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if(checkBox.IsChecked.Value)
            {
                passwordBoxPass.Visibility = Visibility.Hidden;
                textBoxPassword.Text = passwordBoxPass.Password;
                textBoxPassword.Visibility = Visibility.Visible;
            }
            else
            {
                passwordBoxPass.Visibility = Visibility.Visible;
                passwordBoxPass.Password = textBoxPassword.Text;
                textBoxPassword.Visibility = Visibility.Hidden;
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            PageClass.frameObject.Navigate(new PageAddUser());
        }
    }
}
