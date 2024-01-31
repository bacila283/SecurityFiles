using SecurityFiles.WorkWithBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecurityFiles.Auth
{
	public class AuthClass
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Sur_name { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public int Role { get; set; }

		private static List<AuthClass> _authClasses = new List<AuthClass>();

		public static AuthClass CheckUserName(string login, string password)
		{
			foreach (var authClass in _authClasses)
			{
				if(authClass.Login == login && authClass.Password == password)
					return authClass;
				
			}
			MessageBox.Show("Неправильный логин или пароль");
			return null;
		}
		public static void TestAdd()
		{
			AuthClass authClass = new AuthClass();
			authClass.ID = 1;
			authClass.Name = "A";
			authClass.Sur_name = "B";
			authClass.Login = "login";
			authClass.Password = "password";
			authClass.Role = 1;
			_authClasses.Add(authClass);
			JSONSettings.SerObj(_authClasses);
		}
	}

}
