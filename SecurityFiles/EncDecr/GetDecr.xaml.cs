using System;
using System.IO;
using System.Text;
using System.Windows;
using Page = System.Windows.Controls.Page;

namespace SecurityFiles.EncDecr
{
    /// <summary>
    /// Логика взаимодействия для GetDecr.xaml
    /// </summary>
    public partial class GetDecr : Page
    {
        string MainDir = @"C:\Users\bonda\OneDrive\Рабочий стол\TestFolder";
        string Decr = string.Empty;
        string Key = string.Empty;
        string FileName = string.Empty;
        public GetDecr()
        {
            InitializeComponent();
        }

        private void OpenDecFilebtn_Click(object sender, RoutedEventArgs e)
        {
            Decr = EncDecr.Controller.FuOpenFileDialog();
            FileInfo file = new FileInfo(Decr);
            FileName = file.Name;
            string a = "";
            for (int i = 0; i < FileName.Length - 1; i++)
            {
                a += FileName[i];
            }
            FileName = a;
        }

        private void OpenDecKeybtn_Click(object sender, RoutedEventArgs e)
        {

            Key = EncDecr.Controller.FuOpenFileDialog();
        }

        private void GetDecript_Click(object sender, RoutedEventArgs e)
        {
            if (Decr != string.Empty && Key != string.Empty)
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string textfromfile = string.Empty;
                //ваще я хз разумно ли впихивать 2 ридера...
                using StreamReader sr = new StreamReader(Decr, Encoding.GetEncoding(1251), true); //считываем зашифрованный текст из файла 
                {
                    textfromfile = sr.ReadToEnd();
                    //sr.Close();
                }
                string keyfromfile = string.Empty;
                using StreamReader sr_key = new StreamReader(Key, Encoding.GetEncoding(1251), true); //считываем ключ из файла 
                {
                    keyfromfile = sr_key.ReadToEnd();
                    sr.Close();
                }
                var b1 = System.Convert.FromBase64String(textfromfile); //шифрованный текст битами, переводим в биты но из base64

                int c = b1.Length / 256; //считаем число итераций (блоков)

                string a2 = string.Empty; // сюда будем записывать результат дешировки 

                for (int i = 0; i < c; i++) //шаманим с расшифровкой блоков
                {
                    byte[] ewr = new byte[256];
                    Buffer.BlockCopy(b1, i * 256, ewr, 0, 256);
                    a2+= Crypto.UseRSA.Decript(ewr, keyfromfile);
                }

                Directory.CreateDirectory(MainDir + $"\\ Decr {FileName}"); // новая директория под расшифрованный файлик
                FileInfo file = new FileInfo(MainDir + $"\\ Decr {FileName}\\{FileName}"); // создаем новый файлик, который поместим расшифрованый текст
                using (StreamWriter sw = new StreamWriter(MainDir + $"\\ Decr {FileName}\\{FileName}", false, Encoding.GetEncoding(1251))) 
                {
                    sw.Write(a2); //записываем результат дешифровки в файлик
                    sw.Close();
                }
            }
            else
                MessageBox.Show("Не все параметры!");
        }
    }
}
