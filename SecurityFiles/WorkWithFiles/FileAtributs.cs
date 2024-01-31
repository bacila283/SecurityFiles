using SecurityFiles.WorkWithBD;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SecurityFiles.WorkWithFiles
{
	public class FileAtributs
	{
		public int ID { get; set; } //id
		public string FileName { get; set; } //name
		public string AuthorName { get; set; } //author
		public string FileWeight { get; set; }//вес
		public string FileHash { get; set; } //hash
		public string FileCreationTime { get; set; } //время создания
		public string FileType { get; set; } //file type
		public int FatherFile { get; set; } //основной файл (сделал для того, что если файл изменили и добавили)
		public string Key { get; set; } = string.Empty;

		private static List<FileAtributs> _FileAtributs = new List<FileAtributs>();
		public List<FileAtributs> GetTable()
		{
			return _FileAtributs;
		}
		public static void DesrDB()
		{
			_FileAtributs = JSONSettings.DesObj(_FileAtributs);
		}
		public static void AddNewFile(FileAtributs fileAtributs)
		{
			bool status = false;
			foreach (var item in _FileAtributs)
			{
				if (item.FileHash == fileAtributs.FileHash && item.FileCreationTime == fileAtributs.FileCreationTime)
				{
					status = false;
					MessageBox.Show("Данный файл уже существует");
				}

				else status = true;
			}
			if (status == true)
			{
				fileAtributs.ID = CheckLastID();
				_FileAtributs.Add(fileAtributs);
				JSONSettings.SerObj(_FileAtributs);
				MessageBox.Show("Файл добавлен!");
			}
		}
		public static void DeleteFile(FileAtributs fileAtributs)
		{
			bool status = false;
			foreach (var item in _FileAtributs.ToList())
			{
				if (item.FileHash == fileAtributs.FileHash && item.FileCreationTime == fileAtributs.FileCreationTime)
				{
					status = true;
					_FileAtributs.Remove(item);
					JSONSettings.SerObj(_FileAtributs);
					MessageBox.Show("Файл удален!");
				}

				else status = false;
			}
			if (status == false)
			{
				MessageBox.Show("Файла нет в базе");


			}

		}
		private static int CheckLastID()
		{
			int lastid = 0;
			if (_FileAtributs != null)
			{
				foreach (var item in _FileAtributs)
				{
					if (item.ID > lastid)
						lastid = item.ID;
				}
				return lastid + 1;
			}
			else { return 0; }
		}
		public static bool CheckFile(FileAtributs fileAtributs)
		{
			foreach (var item in _FileAtributs)
			{
				if(item.FileHash==fileAtributs.FileHash)
				{
					return true;
				}
			}
			return false;
		}

	}
}
