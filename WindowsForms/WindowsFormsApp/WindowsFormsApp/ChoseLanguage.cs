using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ChoseLanguage : Form
    {

        Form1 f;
        public bool opening_first_time = true;
        public ChoseLanguage(Form1 f)
        {

            InitializeComponent();
            this.f = f;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        public async void button1_Click(object sender, EventArgs e)
        {
            if (!opening_first_time && !f.confirmationBox())
            {
                return;
            }
            f.changeLanguageToENG();
            Hide();

            if (opening_first_time)
            {
               
                f.TeamLoader();
                opening_first_time = false;
            }
        }

        public async void button2_Click(object sender, EventArgs e)
        {
            if (!opening_first_time && !f.confirmationBox())
            {
                return;
            }
            f.changeLanguageToCRO();
            Hide();

            if (opening_first_time)
            {
               
                await Task.Run(() => f.TeamLoader());
                f.showTeamLoader();
                opening_first_time = false;
            }
        }

        public async void ChoseLanguage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (opening_first_time)
            {
                Hide();
                e.Cancel = true;
                f.changeLanguageToCRO();
                
                await Task.Run(() => f.TeamLoader());
                f.showTeamLoader();
                opening_first_time = false;
                return;
            }
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void ChoseLanguage_Load(object sender, EventArgs e)
        {

        }
    }
}
