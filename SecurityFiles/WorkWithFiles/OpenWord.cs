using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using SecurityFiles.Crypto;
using System.Runtime.Intrinsics.Arm;
using System.Collections.Generic;

namespace SecurityFiles.WorkWithFiles
{
	public class OpenFile
	{
		public void Open(int key, string file)
		{

			switch (key)
			{
				case 1:
					OpenWord(file);
					break;
				case 2:
					OpenExcel(file);
					break;
				case 3:
					OpenPowerpoint(file);
					break;
				case 4:
					OpenTxt(file);
					break;
			}
		}
		private void OpenWord(string file)
		{
			string fileexe = @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE"; //CHANGE PATH
			if (File.Exists(file) == true)
			{
				var a = Crypto.HashFromFile.GetHash(file);
				OpenProc(fileexe, file);
			}
			else
			{
				MessageBox.Show("Путь до файла не найден!");
			}
		}
		private void OpenExcel(string file)
		{
			string fileexe = @"C:\Program Files\Microsoft Office\root\Office16\EXCEL.EXE";
			if (File.Exists(file) == true)
			{
				Crypto.HashFromFile.GetHash(file); ;
				OpenProc(fileexe, file);
				
			}
			else
			{
				MessageBox.Show("Путь до файла не найден!");
			}
		}
		private void OpenPowerpoint(string file)
		{
			string fileexe = @"C:\Program Files\Microsoft Office\root\Office16\POWERPNT.EXE";
			if (File.Exists(file) == true)
			{
				Crypto.HashFromFile.GetHash(file);
				OpenProc(fileexe, file);
			}
			else
			{
				MessageBox.Show("Путь до файла не найден!");
			}
		}
		private void OpenTxt(string file)
		{
			if (File.Exists(file) == true)
			{
				//StreamReader sr = new StreamReader(file);
				//string line = sr.ReadToEnd();
				Crypto.HashFromFile.GetHash(file);
			}
			else
			{
				MessageBox.Show("Путь до файла не найден!");
			}
		}
		private void OpenProc(string Fileexe, string arg)
		{
			//ReadFile(arg);
			try
			{
				Process proc = new Process();
				proc.StartInfo.FileName = Fileexe;
				proc.StartInfo.Arguments = "\"" + arg + "\"";
				proc.Start();
			}
			catch {
				MessageBox.Show("Неудалось открыть приложение");
			}
			
		}
		//private static string GetHash(HashAlgorithm hashAlgorithm, string input)
		//{
		//	byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

		//	var sBuilder = new StringBuilder();
		//	for (int i = 0; i < data.Length; i++)
		//	{
		//		sBuilder.Append(data[i].ToString("x2"));
		//	}

		//	return sBuilder.ToString();
		//}
		//private string GetHahFromFile(string path)
		//{
		//	var timecreation = File.GetCreationTime(path);
		//	var main = "";
		//	using StreamReader sr = new StreamReader(path);
		//	{
		//		var fromfile = sr.ReadToEnd();
		//		var timecreationbyte = Encoding.ASCII.GetBytes(timecreation.ToString());
		//		SHA256 sha256 = SHA256.Create();
				
		//		var hash = fromfile + timecreationbyte;
		//		main = GetHash(sha256, hash);
		//		MessageBox.Show($"hash = {main}\ntime = {timecreation}");;
		//		return main;
		//	}
			
		//}
		private string GoodPath(string path) // Работа с пробелами пути в cmd//Не нужно
		{
			path += "\"";
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(path);
			stringBuilder.Replace(@"\", "\"" + @"/" + "\"");
			var a = "\"" + stringBuilder.ToString();

			return a.Remove(a.Length - 2, 2);//надо, потому что на конце поялвяются невидимые символы переноса, мы их удаляем
		}
		static int CountByCharacter(string word, char character) =>
		word.Count(x => x.Equals(character));
	}
}


