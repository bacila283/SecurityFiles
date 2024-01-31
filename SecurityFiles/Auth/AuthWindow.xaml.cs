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

namespace SecurityFiles.Auth
{
	/// <summary>
	/// Логика взаимодействия для AuthWindow.xaml
	/// </summary>
	public partial class AuthWindow : Window
	{
		private Settings.MainSettings mainSettings = new Settings.MainSettings();
		public AuthWindow()
		{
			InitializeComponent();
			Auth.AuthClass.TestAdd();
		}

		private void Enter_Button_Click(object sender, RoutedEventArgs e)
		{
			if (Login_textbox.Text.Length != 0 && Password_textbox.Password.Length != 0)
			{
				var user = Auth.AuthClass.CheckUserName(Login_textbox.Text, Password_textbox.Password);
				if ( user != null)
				{
					Window window = new MainWindow(user);
					window.Show();
					this.Close();
				}
			}
			else
				MessageBox.Show("Введите логин и пароль");
        }

		private void Registration_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
