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
    /// Interaction logic for ChoseReprezentation.xaml
    /// </summary>
    public partial class ChoseReprezentation : Window
    {
        MainWindow mw;
        public ChoseReprezentation(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            FillReprezentationComboBox();
        }


        public async void FillReprezentationComboBox()
        {
            //mw.ShowLoading();
            mw.reprezentations = await Task.Run(() => Contributor.ReprezentationNames());

            //mw.HideLoading();
            foreach (var i in mw.reprezentations)
            {
                cb_repChoser.Items.Add(i);
            }
            cb_repChoser.SelectedItem = mw.reprezentations[0];
        }


        public async void Btn_repChoser_Click(object sender, RoutedEventArgs e)
        {
            //mw.ShowLoading();
            mw.fifa_id = await Contributor.CountryFifaCode(cb_repChoser.Text);
            //mw.HideLoading();
            mw.favRepName = cb_repChoser.Text;
            await mw.CreateTeam(mw.favRepName);
            Hide();
            
            await mw.fillEnemyTeamChooser(mw.rep);
        }

        private void Cb_repChoser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
