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
    /// Interaction logic for UserSettings.xaml
    /// </summary>
    public partial class UserSettings : Window
    {
        MainWindow mw;
        public UserSettings(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void Btn_windowed_Click(object sender, RoutedEventArgs e)
        {
            mw.WindowState = WindowState.Maximized;
            mw.windowsState = "fullscreen";
            Hide();
            mw.ChoseRep();
        }

        private void Btn_fullScr_Click(object sender, RoutedEventArgs e)
        {
            mw.WindowState = WindowState.Normal;
            mw.windowsState = "normal";
            Hide();
            mw.ChoseRep();
        }
    }
}
