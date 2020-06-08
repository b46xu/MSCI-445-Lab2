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
using System.Windows.Shapes;
using System.Net.Mail;

namespace MSCI_445_Lab2
{
    /// <summary>
    /// Interaction logic for Password_Input.xaml
    /// </summary>
    public partial class Password_Input : Window
    {
        public Password_Input()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PasswordBox password1Box = (PasswordBox)this.FindName("password1");
            String password1 = password1Box.Password;
            MainWindow.Send_Email(password1);
        }
    }
}
