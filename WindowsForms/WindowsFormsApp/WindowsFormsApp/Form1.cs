using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        ChoseFavPlayer chosefavplayer;
        public Reprezentation rep;
        ChoseFavPlayer favplayerform;
        public Form1()
        {
            InitializeComponent();
            TeamLoader();
        }

        public async void ShowTeamBox()
        {
            comboBox1.Show();
            label1.Show();

        }



        public async void TeamLoader()
        {
            List<string> countries = await Task.Run(() => DataLayer.Contributor.TeamNames());
            ShowTeamBox();
            comboBox1.DataSource = countries;
            comboBox1.SelectedItem = countries[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public async void button1_Click(object sender, EventArgs e)
        {
            string fifa_code = await Task.Run(() => Contributor.CountryFifaCode(comboBox1.Text));
            chosefavplayer.Show();
            rep = new Reprezentation(comboBox1.Text, fifa_code);
        }

        internal void ShowMain()
        {
            throw new NotImplementedException();
        }

        internal void SetUpMain()
        {
            throw new NotImplementedException();
        }
    }
}
