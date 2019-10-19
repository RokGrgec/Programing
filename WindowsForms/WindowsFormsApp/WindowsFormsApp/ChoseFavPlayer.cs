﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using System.IO;

namespace WindowsFormsApp
{
    public partial class ChoseFavPlayer : Form
    {
        private Form1 form;
        ChoseFavPlayer choseFavPlayer;
        public ChoseFavPlayer()
        {
            InitializeComponent();
            this.form = form;
        }

        private async void FillPlayers(Dictionary<string,PlayerInfo> players)
        {
            foreach (var player in players)
            {
                checkedListBox1.Items.Add(player);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var p in checkedListBox1.CheckedItems.Cast<object>().Select(x => checkedListBox1.GetItemText(x)))
            {
                form.rep.players[p].is_fav_player = true;
            }
            Hide();
            form.SetUpMain();
            form.ShowMain();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
