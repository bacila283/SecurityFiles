using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using SecurityFiles.WorkWithFiles;

namespace SecurityFiles
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private OpenFileClass openFileClass = new OpenFileClass();
		public MainWindow(Auth.AuthClass user)
		{
			InitializeComponent();
			if(!File.Exists("SecFiles.json"))
			{

			}
			
			FileAtributs.DesrDB();
		}
		private void TBOpenFile_Click(object sender, RoutedEventArgs e)
		{
			string path = FuOpenFileDialog();
			if (FileAtributs.CheckFile(WorkWithFiles.FileReg.FileRegestration(path)) == true)
				openFileClass.OpenFile(path);
			else MessageBox.Show("Файл не одобрен!");
		}

		private void Temple_1_Click(object sender, RoutedEventArgs e)
		{
			FileAtributs.AddNewFile(WorkWithFiles.FileReg.FileRegestration(FuOpenFileDialog()));
		}

		private void Temple_2_Click(object sender, RoutedEventArgs e)
		{
			FileAtributs.DeleteFile(WorkWithFiles.FileReg.FileRegestration(FuOpenFileDialog()));
		}

		private void Temple_3_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Template_3");
		}
		private string FuOpenFileDialog()
		{
			OpenFile openWord = new OpenFile();
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "(*.docx;*.xlsx;*.pptx;*.txt)|*.docx;*.xlsx;*.pptx;*.txt;|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == true)//kostya
			{

				if (openFileDialog.SafeFileName.ToString().Contains(".docx"))
				{
					return openFileDialog.FileName;
				}
			}
			else
			{
				MessageBox.Show("Ошибка открытия окна выбора");
				return null;
			}
			return null;
		}
	}
}
