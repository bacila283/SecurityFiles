using Microsoft.Win32;
using System.Windows;

namespace SecurityFiles.WorkWithFiles
{
	public class OpenFileClass
	{
		public void OpenFile(string path)
		{
			OpenFile openWord = new OpenFile();
			//OpenFileDialog openFileDialog = new OpenFileDialog();
			////Uri uri = new Uri(path);
			////openFile.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.jpg;*.png;*.jpeg|All files (*.*)|*.*";
			//openFileDialog.Filter = "(*.docx;*.xlsx;*.pptx;*.txt)|*.docx;*.xlsx;*.pptx;*.txt;|All files (*.*)|*.*";
			//if (openFileDialog.ShowDialog() == true)//kostya
			//{
			//	//try
			//	//{
					if (path.Contains(".docx"))
						openWord.Open(1, path);
					if (path.Contains(".xlsx"))
						openWord.Open(2, path);
					if (path.Contains(".pptx"))
						openWord.Open(3, path);
					if (path.Contains(".txt"))
						openWord.Open(4, path);
			//}
			//	catch
			//	{
			//	MessageBox.Show("Ошибка открытия файла");
			//}
		//}
		//	else
		//	{
		//		MessageBox.Show("Ошибка открытия окна выбора");
		//	}
		}

	}
}
