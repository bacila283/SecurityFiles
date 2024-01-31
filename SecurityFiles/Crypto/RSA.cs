using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurityFiles.Crypto
{
	internal class UseRSA
	{
		private RSACryptoServiceProvider _rsa= new RSACryptoServiceProvider();
		public RSAParameters FullRSA()
		{
			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				rsa.KeySize = 512;
				//string base64string = Convert.ToBase64String(Encoding.UTF8.GetBytes("jiraffy.ru")); //0YLQtdGB0YI=
				//byte[] dataToEncrypt = Convert.FromBase64String(base64string);
				//byte[] untext = Encript(dataToEncrypt, rsa.ExportParameters(false));
				//string text = Decript(untext, rsa.ExportParameters(true));
				//string base64 = Convert.ToBase64String(untext);
				_rsa = rsa;
				return rsa.ExportParameters(false);
			}
		}

		public string Encript(byte[] text)
		{
			using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
			{
				RSAParameters parameters = FullRSA();
				provider.ImportParameters(parameters);
				var a = provider.Encrypt(text, false);
				provider.Dispose();
				return Encoding.ASCII.GetString(a);
			}
		}
		public string Decript(byte[] text)
		{
			RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
			
				provider.ImportParameters(_rsa.ExportParameters(true));
				byte[] a = provider.Decrypt(text, false);
				byte[] q1 = Encoding.UTF8.GetBytes(provider.ToXmlString(true));
				return Convert.ToBase64String(a);
			
		}
	}
}
