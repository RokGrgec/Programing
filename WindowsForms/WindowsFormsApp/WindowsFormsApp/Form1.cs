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





        public async void TestFunctions()
        {
            //Console.WriteLine($"Testing...\nNumber of yellow cards: {await Task.Run(() => Contributor.GetPlayerYellowCardNumber("Eiji KAWASHIMA", "JPN",mat))}");
            List<string> players = await Task.Run(() => Contributor.GetMatchFirstEleven("300331550", "JPN"));
            Console.WriteLine("Starting eleven from japan: ");
            players.ForEach(Console.WriteLine);
            Console.WriteLine("---------------------------");
        }






        public Form1()
        {
            InitializeComponent();
            TeamLoader();
            //Task.Run(()=>TestFunctions());
        }

        public async void ShowTeamBox()
        {
            comboBox1.Show();
            label1.Show();

        }

        public async void showTeamLoader()
        {
            label1.Show();
            comboBox1.Show();
            button1.Show();
            //btn_settings.Show();
        }

        public async void hideTeamLoader()
        {
            label1.Hide();
            comboBox1.Hide();
            button1.Hide();
        }

        public async void TeamLoader()
        {
            List<string> countries = await Task.Run(() => DataLayer.Contributor.TeamNames());
            ShowTeamBox();
            comboBox1.DataSource = countries;
            comboBox1.SelectedItem = countries[0];
        }


        public async void button1_Click(object sender, EventArgs e)
        {
            string fifa_code = await Task.Run(() => Contributor.CountryFifaCode(comboBox1.Text));
            rep = new Reprezentation(comboBox1.Text, fifa_code);

            
            //await Task.Run(() => hideTeamLoader());
            //await Task.Run(() => showLoading());

            await Task.Run(() => rep.SetUp());

            favplayerform.FillPlayers(rep.players);
            favplayerform.Show();
            favplayerform.BringToFront();
        }

        internal void ShowMain()
        {
           
        }

        internal void SetUpMain()
        {
            throw new NotImplementedException();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
