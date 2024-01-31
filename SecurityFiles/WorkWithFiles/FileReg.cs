using SecurityFiles.WorkWithBD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecurityFiles.WorkWithFiles
{
	public class FileReg
	{
		public static FileAtributs FileRegestration(string path)
		{
			FileAtributs fileAtributs = new FileAtributs();
			if (File.Exists(path))
			{
				FileInfo fi = new FileInfo(path);
				
				fileAtributs.FileWeight = fi.Length.ToString();
				fileAtributs.FileCreationTime = File.GetCreationTime(path).ToString();
				fileAtributs.FileName = Path.GetFileName(path);
				fileAtributs.FileType = Path.GetExtension(path);
				fileAtributs.FileHash = Crypto.HashFromFile.GetHash(path);
				fileAtributs.AuthorName = Path.GetFileName(path);//TODO
			}
			return fileAtributs;
		}
	}
}
