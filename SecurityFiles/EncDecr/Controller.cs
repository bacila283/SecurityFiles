using Microsoft.Win32;
using SecurityFiles.WorkWithFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecurityFiles.EncDecr
{
    public class Controller
    {
        public static string FuOpenFileDialog()
        {
            OpenFile openWord = new OpenFile();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.docx;*.xlsx;*.pptx;*.txt)|*.docx;*.xlsx;*.pptx;*.txt;*|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)//kostya
            {

                if (openFileDialog.SafeFileName.ToString().Contains(".docx"))
                {
                    return openFileDialog.FileName;
                }
                if (openFileDialog.SafeFileName.ToString().Contains(".txt"))
                {
                    return openFileDialog.FileName;
                }
                else
                    return openFileDialog.FileName;
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
