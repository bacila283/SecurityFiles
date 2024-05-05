using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecurityFiles.Crypto
{
	public
		class HashFromFile
	{
		public static string GetHash(string path)
		{
			SHA256 sha256 = SHA256.Create();
			string hash;
			var timecreation = File.GetCreationTime(path);
			using StreamReader sr = new StreamReader(path);
			{
				var fromfile = sr.ReadToEnd();
				//Crypto.EncryptFile.CrFile(fromfile);
				var timecreationbyte = Encoding.Unicode.GetBytes(timecreation.ToString());
				hash = fromfile + timecreationbyte;
			}

			//
			byte[] data = sha256.ComputeHash(Encoding.Unicode.GetBytes(hash));

			var sBuilder = new StringBuilder();
			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}
			//MessageBox.Show(sBuilder.ToString());
			return sBuilder.ToString();
		}
	}
}
