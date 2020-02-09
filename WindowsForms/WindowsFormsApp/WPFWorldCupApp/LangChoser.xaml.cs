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

namespace WPFWorldCupApp
{
    /// <summary>
    /// Interaction logic for LangChoser.xaml
    /// </summary>
    public partial class LangChoser : Window
    {
        private MainWindow mw;
        public bool is_first = true;
            
        public LangChoser(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        public async void Btn_eng_Click(object sender, RoutedEventArgs e)
        {
            mw.language = "ENG";
            Hide();
            await mw.changeLangToEng();
            if (is_first)
            {
                mw.userSettings.Show();
                is_first = false;
            }
        }

        public async void Btn_cro_Click(object sender, RoutedEventArgs e)
        {
            mw.language = "CRO";
            Hide();
            await mw.changeLangToCro();
            if (is_first)
            {
                mw.userSettings.Show();
                is_first = false;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
