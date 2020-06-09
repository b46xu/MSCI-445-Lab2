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
        // private field
        private String send_to;
        private String send_from;
        private String msg_subject;
        private String msg_body;

        public MainWindow()
        {
            InitializeComponent();
        }

        // When the user clicks the send button this function will be called
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string[] errors;
            int index = 0;

            TextBox send_to_box = (TextBox)this.FindName("To");
            send_to = send_to_box.Text;
            // the isEmpty is most likely redudent here. We can do 2 checks for a more custom message
            // or simply take this out
            if (!IsValidEmail(send_to) || IsEmpty(send_to))
            {
                errors[index] = "Please ensure the recipient email is a valid email address";
                index++;
            }

            TextBox send_from_box = (TextBox)this.FindName("From");
            send_from = send_to_box.Text;
            if (!IsValidEmail(send_from) || IsEmpty(send_from))
            {
                errors[index] = "Please ensure the sender email is a valid email address";
                index++;
            }

            TextBox subject_box = (TextBox)this.FindName("Subject");
            msg_subject = send_to_box.Text;
            if (IsEmpty(msg_subject))
            {
                errors[index] = "Please include a subject";
                index++;
            }

            TextBox body_box = (TextBox)this.FindName("Body");
            msg_body = body_box.Text;
            if (IsEmpty(msg_body))
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
        bool IsEmpty(string input)
        {
            if (input == "")
            {
                return false;
            }
            return true;
        }
        //Do we need this function?
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        // Send_Email function is used to send an email
        public static void Send_Email(String password)
        {
            //get from and to here 
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential("xbht0412@gmail.com", password1),
                EnableSsl = true,
            };

            smtpClient.Send(send_to, send_from, msg_subject, msg_body);


        }
    }


}
