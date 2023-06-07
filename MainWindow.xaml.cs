using DemoWPF.DataApp;
using DemoWPF.PageApp;
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
using System.Data.SqlClient;
namespace DemoWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            PageClass.frameObject = frameMain;
            PageClass.connectDB = new user50Entities();
            frameMain.Navigate(new PageLogin(textBlockName));
        }

        private bool NumBetween(int number, int first, int second) => number >= first && number <= second;

        public void Datemessage(TextBlock textblock)
        {
            int hour = DateTime.Now.Hour;
            if (NumBetween(hour, 12, 16))
                textBlockName.Text = "добрый день";
            else if (NumBetween(hour, 17, 23))
                textBlockName.Text = "добрый вечер";
            else if (NumBetween(hour, 8, 11))
                textBlockName.Text = "доброе утро";
            else
                textBlockName.Text = "доброй ночи";
        }
    }
}
