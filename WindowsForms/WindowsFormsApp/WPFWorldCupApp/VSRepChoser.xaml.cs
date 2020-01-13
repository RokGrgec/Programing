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
using DataLayer;

namespace WPFWorldCupApp
{
    /// <summary>
    /// Interaction logic for VSRepChoser.xaml
    /// </summary>
    public partial class VSRepChoser : Window
    {
        MainWindow mw;
        public VSRepChoser(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        public async void Btn_VSrepChoser_Click(object sender, RoutedEventArgs e)
        {
            //mw.ShowLoading();
            mw.VSFifa_id = await Contributor.CountryFifaCode(cb_VSrepChoser.Text);
            //mw.HideLoading();
            mw.VSRepName = cb_VSrepChoser.Text;

            await mw.CreateEnemyTeam(mw.VSRepName);
            await mw.SetAwayTeamLabels(mw.VSRep);
            Hide();
        }
    }
}
