﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Reprezentation rep;
        ChoseFavPlayer favplayerform;
        ChoseLanguage lang_form;
        RangLists rangLists;

        public string q;
        public string a;

        public string fifa_id;



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
            Run();
            //Task.Run(()=>TestFunctions());
        }

        public async void Run()
        {

            hideTeamLoader();
            HideMain();

            lang_form = new ChoseLanguage(this);
            favplayerform = new ChoseFavPlayer(this);
            rangLists = new RangLists(this);

            try
            {

                List<string> userFile = Contributor.ReadConfigFile();
                List<string> favPlayers = userFile[2].Split(',').ToList();
                if (userFile[0] == "cro") { changeLanguageToCRO(); }
                else { changeLanguageToENG(); }
                lang_form.opening_first_time = false;
                fifa_id = await Contributor.CountryFifaCode(userFile[1]);
                rep = new Reprezentation(userFile[1], fifa_id);
                await Task.Run(() => rep.SetUp());
                foreach (var p in favPlayers)
                {
                    if (p == "") { continue; }
                    rep.players[p].is_fav_player = true;
                }
                await Task.Run(() => FillDgv());
                ShowMain();

            }
            catch (Exception e)
            {
                if (e is FileNotFoundException)
                {
                    lang_form.opening_first_time = true;
                    await Task.Run(() => lang_form.BringToFront());
                    lang_form.Show();
                }
               
            }

        }


        public async void ShowMain()
        {
            showLoading();
            pnl_favplayers.Show();
            pnl_allplayers.Show();
            btn_ranglist.Show();
            btn_languages.Show();
            hideLoading();
        }

        public async void HideMain()
        {
            showLoading();
            pnl_favplayers.Hide();
            pnl_allplayers.Hide();
            btn_ranglist.Hide();
            btn_languages.Hide();
            hideLoading();
        }



        public async void showTeamLoader()
        {
            label1.Show();
            comboBox1.Show();
            button1.Show();
            btn_languages.Hide();
        }

        public async void hideTeamLoader()
        {
            label1.Hide();
            comboBox1.Hide();
            button1.Hide();
        }

       


        public async void TeamLoader()
        {
            List<string> countries = await Task.Run(() => Contributor.ReprezentationNames());
            showTeamLoader();
            comboBox1.DataSource = countries;
            comboBox1.SelectedItem = countries[0];
        }


        public async void button1_Click(object sender, EventArgs e)
        {

            string fifa_code = await Task.Run(() => Contributor.CountryFifaCode(comboBox1.Text));
            rep = new Reprezentation(comboBox1.Text, fifa_code);

            //rep = new Reprezentation("24", "KOR");

            
            await Task.Run(() => hideTeamLoader());
            await Task.Run(() => showLoading());

            await Task.Run(() => rep.SetUp());

            favplayerform.FillPlayers(rep.players);
            favplayerform.Show();
            favplayerform.BringToFront();
        }

        public async void FillDgv()
        {
            dgv_favplayers.Rows.Clear();
            dgv_allplayers.Rows.Clear();

            foreach (var p in rep.players)
            {
                if (p.Value.is_fav_player)
                {
                    dgv_favplayers.Rows.Add(
                        new object[] {
                        //i,//image in table to add
                        p.Value.player_name,
                        p.Value.player_number,
                        p.Value.position,
                        p.Value.is_captain?"C":""
                        });
                }
                else
                {
                    dgv_allplayers.Rows.Add(
                    new object[] {
                        //i,//image to add
                        p.Value.player_name,
                        p.Value.player_number,
                        p.Value.position,
                        p.Value.is_captain?"C":""
                    });
                }
            }
        }


        public void showLoading()
        {
            pb_loading.BringToFront();
            pb_loading.Show();

        }
        public void hideLoading()
        {
            pb_loading.BringToFront();
            pb_loading.Hide();
        }



        public bool confirmationBox() => MessageBox.Show(q, a, MessageBoxButtons.YesNo) == DialogResult.Yes ? true : false;

        public void changeLanguageToENG()
        {
            //translate
        }

        public void changeLanguageToCRO()
        {
            //translate
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_languages_Click(object sender, EventArgs e)
        {
            lang_form.Show();
        }

        private void btn_ranglist_Click(object sender, EventArgs e)
        {
            rangLists.FillRangListsDgv();
            rangLists.Show();
        }

        private void pb_loading_Click(object sender, EventArgs e)
        {

        }
    }
}