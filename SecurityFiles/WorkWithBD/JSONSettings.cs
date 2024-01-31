using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SecurityFiles.WorkWithBD
{
	public class JSONSettings
	{
		public static void SerObj(List<WorkWithFiles.FileAtributs> fileatr)
		{
			string formJson = JsonConvert.SerializeObject(fileatr, Formatting.Indented);
			using (StreamWriter sw = new StreamWriter("SecFiles.json"))
			{
				sw.WriteLine(formJson);
			}
		}
		public static List<WorkWithFiles.FileAtributs> DesObj(List<WorkWithFiles.FileAtributs> fileatr)
		{
			if (System.IO.File.Exists("SecFiles.json"))//MainTable.json
				using (StreamReader sr = new StreamReader("SecFiles.json"))
				{
					var table = sr.ReadToEnd();
					fileatr = JsonConvert.DeserializeObject<List<WorkWithFiles.FileAtributs>>(table);
					return fileatr;
				}
			else
			return fileatr;
		}
		public static void SerObj(List<Auth.AuthClass> fileatr)
		{
			string formJson = JsonConvert.SerializeObject(fileatr, Formatting.Indented);
			using (StreamWriter sw = new StreamWriter("Auth.json"))
			{
				sw.WriteLine(formJson);
			}
		}
		public static List<Auth.AuthClass> DesObj(List<Auth.AuthClass> fileatr)
		{
			if (System.IO.File.Exists("Auth.json"))//MainTable.json
				using (StreamReader sr = new StreamReader("Auth.json"))
				{
					var table = sr.ReadToEnd();
					fileatr = JsonConvert.DeserializeObject<List<Auth.AuthClass>>(table);;
					return fileatr;
				}
			else
				return fileatr;
		}
	}
}
