using System.IO;

namespace SecurityFiles.Settings
{
	internal class MainSettings
	{
		public int Id_user { get; set; }
		public string Password { get; set; }
		public long RandNumber { get; set; }
		public string Username { get; set; }
		public string Surname { get; set; }

		//

		public void CreateNewUser(bool yesno) //Если есть акк или его нет 
		{

			using StreamReader sr = new StreamReader("MainSettings.json");
			{
				var a = sr.ReadToEnd();
				
			};

		}
	}


}
