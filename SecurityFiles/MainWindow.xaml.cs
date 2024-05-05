using Microsoft.Win32;
using SecurityFiles.Crypto;
using SecurityFiles.WorkWithFiles;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

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

            if (!File.Exists("SecFiles.json"))
            {

            }

            FileAtributs.DesrDB();
        }
        private void TBOpenFile_Click(object sender, RoutedEventArgs e)
        {
            string path = EncDecr.Controller.FuOpenFileDialog();
            if (path != null && FileAtributs.CheckFile(WorkWithFiles.FileReg.FileRegestration(path)) == true)
                openFileClass.OpenFile(path);
            else MessageBox.Show("Файл не одобрен!");
        }

        private void Temple_1_Click(object sender, RoutedEventArgs e)
        {
            FileAtributs.DeleteFile(WorkWithFiles.FileReg.FileRegestration(EncDecr.Controller.FuOpenFileDialog()));
        }

        private void Temple_2_Click(object sender, RoutedEventArgs e)
        {
            FileAtributs.DeleteFile(WorkWithFiles.FileReg.FileRegestration(EncDecr.Controller.FuOpenFileDialog()));
        }

        private void Temple_3_Click(object sender, RoutedEventArgs e)
        {
            Window window = new NewEnc(1);
            window.Show();
        }
        private void Temple_4_Click(object sender, RoutedEventArgs e)
        {
            Window window = new NewEnc(2);
            window.Show();
        }
        


    }
}
