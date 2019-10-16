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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
