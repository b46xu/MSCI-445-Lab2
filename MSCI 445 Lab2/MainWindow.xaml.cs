using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace MSCI_445_Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
		<Label x:Name="To" Content="To:"   HorizontalAlignment="Left" Height="30" Margin="80,50,0,0" VerticalAlignment="Top" Width="80" AutomationProperties.Name="To"/>
		<Label x:Name="From" Content="From:" HorizontalAlignment="Left" Height="30" Margin="80,90,0,0" VerticalAlignment="Top" Width="80"/>
		<Label x:Name="Subject" Content="Subject:" HorizontalAlignment="Left" Height="36" Margin="80,130,0,0" VerticalAlignment="Top" Width="80"/>
		<TextBox HorizontalAlignment = "Left" Height="20" Margin="210,55,0,0" TextWrapping="Wrap" Text="&#xD;&#xA;" VerticalAlignment="Top" Width="125" TextAlignment="Center" TextChanged="TextBox_TextChanged"/>
		<Label x:Name="Body" Content="Body:" HorizontalAlignment="Left" Height="25" Margin="80,170,0,0" VerticalAlignment="Top" Width="80"/>
		<TextBlock HorizontalAlignment = "Left" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top"/>
		<TextBox HorizontalAlignment = "Left" Height="20" Margin="210,95,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="125"/>
		<TextBox HorizontalAlignment = "Left" Height="20" Margin="210,135,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="185"/>
		<TextBox HorizontalAlignment = "Left" Height="155" Margin="210,165,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="185"/>
		<Button Content = "Send" HorizontalAlignment="Left" VerticalAlignment="Top" Width="75" Margin="425,51,0,0" Click="ButtonClick"/>

		// User click 
		private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string[] errors;
            int index = 0;

            TextBox send_to_box = (TextBox)this.FindName("To");
            String send_to = send_to_box.Text;
            // the isEmpty is most likely redudent here. We can do 2 checks for a more custom message
            // or simply take this out
            if (!IsValidEmail(send_to) || IsEmpty(send_to))
            {
                errors[index] = "Please ensure the recipient email is a valid email address";
                index++;
            }

            TextBox send_from_box = (TextBox)this.FindName("From");
            String send_to = send_to_box.Text;
            if (!IsValidEmail(send_to) || IsEmpty(send_to))
            {
                errors[index] = "Please ensure the sender email is a valid email address";
                index++;
            }

            TextBox subject_box = (TextBox)this.FindName("Subject");
            String send_to = send_to_box.Text;
            if (IsEmpty(send_to))
            {
                errors[index] = "Please include a subject";
                index++;
            }

            TextBox body_box = (TextBox)this.FindName("Body");
            String body = body_box.Text;
            if (IsEmpty(body))
            {
                errors[index] = "Please include a body";
                index++;
            }


            if (index > 0)
            {
                for (int i = 0; i < errors.Length; i++)
                {
                    // we need to display the error messages
                    Console.WriteLine(errors[i]);
                }

            }
            else
            {
                Password_Input password_Input = new Password_Input();
                this.Visibility = Visibility.Hidden;
                password_Input.Show();

            }

        }
        // This function is used to validate emails. If an email can be properly parsed into the 
        // native MailAddress lib type, it is a vlaid email and will return true. We decided to take
        // this approach over reggex to enhance the readability of the code.
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        bool IsEmpty(string name, string input)
        {
            if (input == "")
            {
                return false;
            }
            return true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        public static void Send_Email(String password1)
        {

            //get from and to here 


            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential("xbht0412@gmail.com", password1),
                EnableSsl = true,
            };

            smtpClient.Send("xbht0412@gmail.com", "xbht0412@gmail.com", "testing", "body");


        }
    }


}
