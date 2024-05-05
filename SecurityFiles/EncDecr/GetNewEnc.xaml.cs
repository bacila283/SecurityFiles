using SecurityFiles.Crypto;
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

namespace SecurityFiles.EncDecr
{
    /// <summary>
    /// Логика взаимодействия для GetNewEnc.xaml
    /// </summary>
    public partial class GetNewEnc : Page
    {
        public GetNewEnc()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            string path = EncDecr.Controller.FuOpenFileDialog();
            if (path != null)
            {
                FileInfo finfo = new FileInfo(path + "s"); 
                if (!finfo.Exists)
                {
                    string textfromfile = string.Empty;
                    string newdir = string.Empty;
                    string Enc = string.Empty;
                    UseRSA useRSA = new UseRSA();

                    var privkey = useRSA.NewRSAkey(); // создаем новый RSA ключ 

                    var pub = useRSA.PrivPubKey(privkey, false); //публичный ключ
                    var priv = useRSA.PrivPubKey(privkey, true); //приватный ключ

                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    using StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251), true);
                    {
                        textfromfile = sr.ReadToEnd(); //читаем текст,который надо зашифровать
                        sr.Close();

                        var fulltext = Encoding.GetEncoding(1251).GetBytes(textfromfile);
                        float lnt_double = fulltext.Length / (float)53.0; //считаем сколько блоков нужно, чтобы зашифровать текст
                        int lnt_int = (int)lnt_double;
                        if (lnt_double < 1 || lnt_double % 1 != 0)
                        {
                            lnt_int++;
                        }

                        byte[] enc_bytes = new byte[lnt_int * 53];

                        for (int i = 0; i < lnt_int; i++) // шифруем блоки и записываем результат в "Enc"
                        {
                            byte[] ewr = new byte[53];
                            if (i < lnt_int - 1)
                            {
                                Buffer.BlockCopy(fulltext, i * 53, ewr, 0, 53);
                            }
                            else
                            {
                                Buffer.BlockCopy(fulltext, i * 53, ewr, 0, fulltext.Length - (i * 53));
                            }
                            Enc += useRSA.Encript(ewr, privkey,false); 
                        }
                    };

                    try
                    {
                        newdir = finfo.Directory.ToString() + $"\\{finfo.Name}";
                        Directory.CreateDirectory(newdir); //создаем директорию с зашифрованным файлом
                        File.Create(newdir + $"\\pubkey").Close(); // создаем пустые файлы с публичным 
                        File.Create(newdir + $"\\privkey").Close(); // и приватным ключами

                        //////////////////ОБЯЗАТЕЛЬНО ЗАКИНУТЬ РАБОТУ С ФАЙЛАМИ В ОТДЕЛЬНЫЙ КЛАСС!!!!!!!! 
                        using (StreamWriter sw = new StreamWriter(newdir + "\\pubkey", false, Encoding.GetEncoding(1251)))
                        {
                            sw.Write(pub); //записываем публичный ключ в файл
                            sw.Close();
                        }
                        using (StreamWriter sw = new StreamWriter(newdir + "\\privkey", false, Encoding.GetEncoding(1251)))
                        {
                            sw.Write(priv);//записываем приватный ключ в файл
                            sw.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    using (StreamWriter sw = new StreamWriter(newdir + $"\\{finfo.Name}", false, Encoding.GetEncoding(1251)))
                    {
                        //вот тут сложно...
                        //полученный зашифрованный текст, переводим в кодировку BASE64 - https://ru.wikipedia.org/wiki/Base64
                        //а потом записываем ее в файл
                        sw.Write(System.Convert.ToBase64String(Encoding.GetEncoding(1251).GetBytes(Enc)));
                        sw.Close();
                    }
                    MessageBox.Show($"Файл {finfo.Name} создан!");
                }
            }
        }

        private void Sendbtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
