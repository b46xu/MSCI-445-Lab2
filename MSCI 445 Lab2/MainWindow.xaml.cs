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

		
		private void ButtonClick(object sender, RoutedEventArgs e)
		{

			Password_Input password_Input = new Password_Input();
			this.Visibility = Visibility.Hidden;
			password_Input.Show();
			
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		

		public static void Send_Email(String password1) {

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
