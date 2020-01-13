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
    public partial class RangLists : Form
    {
        Form1 f;
        public RangLists(Form1 f)
        {
            InitializeComponent();
            this.f = f;
        }


        public async void FillRangListsDgv()
        {
            dvg_PlayersInfo.Rows.Clear();
            dvg_matchInfo.Rows.Clear();
            
            //Image i = Image.FromFile(@"..\..\..\static\tux.png");

            foreach (var p in f.rep.firsteleven)
            {
                dvg_PlayersInfo.Rows.Add(
                    new object[] {
                        //i,
                        (f.rep.players[p].is_captain?"C":""),
                        (f.rep.players[p].is_fav_player?"★":""),
                        f.rep.players[p].player_name,
                        f.rep.players[p].num_of_cards,
                        f.rep.players[p].num_of_goals,
                    });
            }
            foreach (var p in f.rep.substitutions)
            {
                dvg_PlayersInfo.Rows.Add(
                    new object[] {
                        //i,
                        (f.rep.players[p].is_captain?"C":""),
                        (f.rep.players[p].is_fav_player?"★":""),
                        f.rep.players[p].player_name,
                        f.rep.players[p].num_of_cards,
                        f.rep.players[p].num_of_goals,
                    });
            }

            foreach (Match m in f.rep.matches)
            {
                dvg_matchInfo.Rows.Add(
                    new object[]
                    {
                        m.location,
                        m.attendance,
                        m.home_team,
                        m.away_team
                    });
            }

        }

        private void RangLists_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
