using SecurityFiles.EncDecr;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SecurityFiles
{
    /// <summary>
    /// Логика взаимодействия для NewEnc.xaml
    /// </summary>
    public partial class NewEnc : Window
    {
        public NewEnc(int x)
        {
            InitializeComponent();
            switch(x)
            {
                case 1:
                    MainFrame.Content = new GetNewEnc();
                    break;
                case 2:
                    MainFrame.Content = new GetDecr();
                    break;
            }
        }

        private void qiut_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}
