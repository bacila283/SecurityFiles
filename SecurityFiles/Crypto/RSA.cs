using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace SecurityFiles.Crypto
{
    public class UseRSA
    {
        private RSACryptoServiceProvider _rsa = new RSACryptoServiceProvider();
        public RSAParameters NewRSAkey()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                _rsa = rsa;
                return _rsa.ExportParameters(true);
            }
        }
        public string PrivPubKey(RSAParameters parameters, bool _choise) // false - pubkey, true - priv key
        {

            RSACryptoServiceProvider key = new RSACryptoServiceProvider();
            using (RSACryptoServiceProvider RSA = key)
            {
                RSA.ImportParameters(parameters);
                key = RSA;
                return key.ToXmlString(_choise);
            }
        }

        public string Encript(byte[] text, RSAParameters privkey, bool DoOAEPPadding)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
            {
                RSAParameters parameters = privkey;
                provider.ImportParameters(parameters);
                provider.ExportParameters(false);
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var a = provider.Encrypt(text, false); // false
                provider.Dispose();
                return Encoding.GetEncoding(1251).GetString(a);
            }
        }
        public static string Decript(byte[] text, string privkey)
        {
            byte[] a = new byte[text.Length];
            using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
            {
                provider.FromXmlString(privkey);
                provider.ExportParameters(false);
                return Encoding.GetEncoding(1251).GetString(provider.Decrypt(text, false));
            }

        }
    }
}
