using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLayer;

namespace WPFWorldCupApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LangChoser langChoser;
        public UserSettings userSettings;
        public string language;



        public string favRepName;
        public string fifa_id;
        public string VSFifa_id;
        public string VSRepName;
        public Reprezentation rep;
        public Reprezentation VSRep;
        public Match match = new Match();

        public string windowsState = "";
        public List<string> reprezentations = new List<string>();

        /*forms*/

        public ChoseReprezentation choseReprezentation;
        public VSRepChoser vsRepChoser;
        public LoadingWindow loadingWindow = new LoadingWindow();
        

        public MainWindow()
        {
            InitializeComponent();
            run();
        }

        public async void run()
        {
            Hide();

            langChoser = new LangChoser(this);
            userSettings = new UserSettings(this);
            choseReprezentation = new ChoseReprezentation(this);
            vsRepChoser = new VSRepChoser(this);
            

            //put loading
            try
            {
                //[0] language
                //[1] name 
                //[2] fav players(split with,)
                List<string> config = Contributor.ReadConfigFile();
                language = config[0];
                favRepName = config[1];
                fifa_id = await Contributor.CountryFifaCode(favRepName);

                if (language == "ENG") { await changeLangToEng(); }
                else { await changeLangToCro(); }
                langChoser.is_first = false;
                await CreateTeam(favRepName);
                await fillEnemyTeamChooser(rep);
            }
            catch (FileNotFoundException)
            {
                langChoser.Show();
            }
        }

        public async Task changeLangToEng()
        {

        }

        public async Task changeLangToCro()
        {
            
        }

        public async void ShowMain()
        {
            Show();
        }
        public async void fillRepCB()
        {
            foreach (var i in reprezentations)
            {
                //cb_reprezentations.Items.Add(i);
            }
            //cb_reprezentations.SelectedItem = favRepName;
        }


        public async Task fillEnemyTeamChooser(Reprezentation r)
        {
            vsRepChoser.cb_VSrepChoser.Items.Clear();
            string n = "";
            foreach (var m in r.matches)
            {
                if (m.home_team == r.teamName)
                {
                    vsRepChoser.cb_VSrepChoser.Items.Add(m.away_team);
                    n = m.away_team;
                }
                else
                {
                    vsRepChoser.cb_VSrepChoser.Items.Add(m.home_team);
                }
            }
            vsRepChoser.cb_VSrepChoser.SelectedItem = n;
            showVSRepChoserForm();
        }

        private void showVSRepChoserForm()
        {
            vsRepChoser.Show();
        }


        public void ChoseRep()
        {
            choseReprezentation.Show();
        }
        // ------------------------------------------------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------

        public async Task CreateTeam(string repName)
        {
            rep = new Reprezentation(repName, fifa_id);
            await rep.SetUp();
            await SetHomeTeamLabels(rep);
            
        }

        public async Task SetHomeTeamLabels(Reprezentation rep)
        {
            //await showHomeTeamField();
            int numOfDefenders = 0;
            int numOfMidfielders = 0;
            int numOfForwards = 0;
            List<PlayerInfo> playerInfos = new List<PlayerInfo>();

            string goalie = "";

            List<string> defenders = new List<string>();

            List<string> midfielders = new List<string>();

            List<string> forwards = new List<string>();

            foreach (var p in rep.firsteleven)
            {
                playerInfos.Add(rep.players[p]);
                switch (rep.players[p].position)
                {
                    case "Defender":
                        numOfDefenders++;
                        break;
                    case "Midfield":
                        numOfMidfielders++;
                        break;
                    case "Forward":
                        numOfForwards++;
                        break;
                }
            }

            // Filling lists
            foreach (var player in playerInfos)
            {
                if (player.position == "Goalie")
                {
                    goalie = player.player_name;
                }
                else if (player.position == "Defender")
                {
                    defenders.Add(player.player_name);
                }
                else if (player.position == "Midfield")
                {
                    midfielders.Add(player.player_name);
                }
                else if (player.position == "Forward")
                {
                    forwards.Add(player.player_name);
                }
            }

            // Filling labels
            lbl_goalieChosenRep.Content = goalie;
            #region Defenders
            if (numOfDefenders == 3)
            {
                lbl_vsDef1.Content = defenders[0];
                lbl_vsDef2.Content = defenders[1];
                lbl_vsDef3.Content = defenders[2];
                cb_vsDef4.Visibility = Visibility.Hidden;
                cb_vsDef4.Visibility = Visibility.Hidden;
                lbl_vsDef4.Visibility = Visibility.Hidden;
                lbl_vsDef5.Visibility = Visibility.Hidden;
            }
            else if (numOfDefenders == 4)
            {
                lbl_vsDef1.Content = defenders[0];
                lbl_vsDef2.Content = defenders[1];
                lbl_vsDef3.Content = defenders[2];
                lbl_vsDef4.Content = defenders[3];
                cb_vsDef5.Visibility = Visibility.Hidden;
                lbl_vsDef5.Visibility = Visibility.Hidden;
            }
            else if (numOfDefenders == 5)
            {
                lbl_vsDef1.Content = defenders[0];
                lbl_vsDef2.Content = defenders[1];
                lbl_vsDef3.Content = defenders[2];
                lbl_vsDef4.Content = defenders[3];
                lbl_vsDef5.Content = defenders[4];
            }
            #endregion

            #region Midfielders
            if (numOfMidfielders == 2)
            {
                lbl_vsMid1.Content = midfielders[0];
                lbl_vsMid2.Content = midfielders[1];
                cb_vsMid3.Visibility = Visibility.Hidden;
                cb_vsMid4.Visibility = Visibility.Hidden;
                cb_vsMid5.Visibility = Visibility.Hidden;
                cb_vsMid6.Visibility = Visibility.Hidden;
                lbl_vsMid3.Visibility = Visibility.Hidden;
                lbl_vsMid4.Visibility = Visibility.Hidden;
                lbl_vsMid5.Visibility = Visibility.Hidden;
                lbl_vsMid6.Visibility = Visibility.Hidden;
            }
            else if (numOfMidfielders == 3)
            {
                lbl_vsMid1.Content = midfielders[0];
                lbl_vsMid2.Content = midfielders[1];
                lbl_vsMid3.Content = midfielders[2];
                cb_vsMid4.Visibility = Visibility.Hidden;
                cb_vsMid5.Visibility = Visibility.Hidden;
                cb_vsMid6.Visibility = Visibility.Hidden;
                lbl_vsMid4.Visibility = Visibility.Hidden;
                lbl_vsMid5.Visibility = Visibility.Hidden;
                lbl_vsMid6.Visibility = Visibility.Hidden;
            }
            else if (numOfMidfielders == 4)
            {
                lbl_vsMid1.Content = midfielders[0];
                lbl_vsMid2.Content = midfielders[1];
                lbl_vsMid3.Content = midfielders[2];
                lbl_vsMid4.Content = midfielders[3];
                cb_vsMid5.Visibility = Visibility.Hidden;
                cb_vsMid6.Visibility = Visibility.Hidden;
                lbl_vsMid5.Visibility = Visibility.Hidden;
                lbl_vsMid6.Visibility = Visibility.Hidden;
            }
            else if (numOfMidfielders == 5)
            {
                lbl_vsMid1.Content = midfielders[0];
                lbl_vsMid2.Content = midfielders[1];
                lbl_vsMid3.Content = midfielders[2];
                lbl_vsMid4.Content = midfielders[3];
                lbl_vsMid5.Content = midfielders[4];
                cb_vsMid6.Visibility = Visibility.Hidden;
                lbl_vsMid6.Visibility = Visibility.Hidden;
            }
            else if (numOfMidfielders == 5)
            {
                lbl_vsMid1.Content = midfielders[0];
                lbl_vsMid2.Content = midfielders[1];
                lbl_vsMid3.Content = midfielders[2];
                lbl_vsMid4.Content = midfielders[3];
                lbl_vsMid5.Content = midfielders[4];
                lbl_vsMid6.Content = midfielders[5];
            }
            #endregion

            #region Forwards
            if (numOfForwards == 1)
            {
                lbl_vsAway1.Content = forwards[0];
                cb_vsAway2.Visibility = Visibility.Hidden;
                cb_vsAway3.Visibility = Visibility.Hidden;
                cb_vsAway4.Visibility = Visibility.Hidden;
                lbl_vsAway2.Visibility = Visibility.Hidden;
                lbl_vsAway3.Visibility = Visibility.Hidden;
                lbl_vsAway4.Visibility = Visibility.Hidden;
            }
            else if (numOfForwards == 2)
            {
                lbl_vsAway1.Content = forwards[0];
                lbl_vsAway2.Content = forwards[1];
                cb_vsAway3.Visibility = Visibility.Hidden;
                cb_vsAway4.Visibility = Visibility.Hidden;
                lbl_vsAway3.Visibility = Visibility.Hidden;
                lbl_vsAway4.Visibility = Visibility.Hidden;
            }
            else if (numOfMidfielders == 3)
            {
                lbl_vsAway1.Content = forwards[0];
                lbl_vsAway2.Content = forwards[1];
                lbl_vsAway3.Content = forwards[2];
                cb_vsAway4.Visibility = Visibility.Hidden;
                lbl_vsAway4.Visibility = Visibility.Hidden;
            }
            else if (numOfForwards == 4)
            {
                lbl_vsAway1.Content = forwards[0];
                lbl_vsAway2.Content = forwards[1];
                lbl_vsAway3.Content = forwards[2];
                lbl_vsAway4.Content = forwards[3];
            }
            #endregion
        }

        public async Task CreateEnemyTeam(string teamName)
        {
            VSRep = new Reprezentation(teamName, VSFifa_id);
            await VSRep.SetUp();
            await SetAwayTeamLabels(VSRep);

            //await ShowLoadingForm();

            Thread.Sleep(500); // USAGE

            //await HideLoadingForm();

            fillRepCB();
            Show();
        }

        public async Task SetAwayTeamLabels(Reprezentation VSRep)
        {

            //await showAwayTeamField();
            int numOfDefenders = 0;
            int numOfMidfielders = 0;
            int numOfForwards = 0;
            List<PlayerInfo> playerInfos = new List<PlayerInfo>();

            string goalie = "";

            List<string> defenders = new List<string>();

            List<string> midfielders = new List<string>();

            List<string> forwards = new List<string>();

            foreach (var p in VSRep.firsteleven)
            {
                playerInfos.Add(VSRep.players[p]);
                switch (VSRep.players[p].position)
                {
                    case "Defender":
                        numOfDefenders++;
                        break;
                    case "Midfield":
                        numOfMidfielders++;
                        break;
                    case "Forward":
                        numOfForwards++;
                        break;
                }
            }

            // Filling lists
            foreach (var player in playerInfos)
            {
                if (player.position == "Goalie")
                {
                    goalie = player.player_name;
                }
                else if (player.position == "Defender")
                {
                    defenders.Add(player.player_name);
                }
                else if (player.position == "Midfield")
                {
                    midfielders.Add(player.player_name);
                }
                else if (player.position == "Forward")
                {
                    forwards.Add(player.player_name);
                }
            }

            // Filling labels
            lbl_vsGoalie.Content = goalie;
            #region Defenders
            if (numOfDefenders == 3)
            {
                lbl_def1.Content = defenders[0];
                lbl_def2.Content = defenders[1];
                lbl_def3.Content = defenders[2];
                cb_def4.Visibility = Visibility.Hidden;
                cb_def5.Visibility = Visibility.Hidden;
                lbl_def4.Visibility = Visibility.Hidden;
                lbl_def5.Visibility = Visibility.Hidden;
            }
            else if (numOfDefenders == 4)
            {
                lbl_def1.Content = defenders[0];
                lbl_def2.Content = defenders[1];
                lbl_def3.Content = defenders[2];
                lbl_def4.Content = defenders[3];
                cb_def5.Visibility = Visibility.Hidden;
                lbl_def5.Visibility = Visibility.Hidden;
            }
            else if (numOfDefenders == 5)
            {
                lbl_def1.Content = defenders[0];
                lbl_def2.Content = defenders[1];
                lbl_def3.Content = defenders[2];
                lbl_def4.Content = defenders[3];
                lbl_def5.Content = defenders[4];
            }
            #endregion

            #region Midfielders
            if (numOfMidfielders == 2)
            {
                lbl_mid1.Content = midfielders[0];
                lbl_mid2.Content = midfielders[1];
                cb_mid3.Visibility = Visibility.Hidden;
                cb_mid4.Visibility = Visibility.Hidden;
                cb_mid5.Visibility = Visibility.Hidden;
                cb_mid6.Visibility = Visibility.Hidden;
                lbl_mid3.Visibility = Visibility.Hidden;
                lbl_mid4.Visibility = Visibility.Hidden;
                lbl_mid5.Visibility = Visibility.Hidden;
                lbl_mid6.Visibility = Visibility.Hidden;
            }
            else if (numOfMidfielders == 3)
            {
                lbl_mid1.Content = midfielders[0];
                lbl_mid2.Content = midfielders[1];
                lbl_mid3.Content = midfielders[2];
                cb_mid4.Visibility = Visibility.Hidden;
                cb_mid5.Visibility = Visibility.Hidden;
                cb_mid6.Visibility = Visibility.Hidden;
                lbl_mid4.Visibility = Visibility.Hidden;
                lbl_mid5.Visibility = Visibility.Hidden;
                lbl_mid6.Visibility = Visibility.Hidden;
            }
            else if (numOfMidfielders == 4)
            {
                lbl_mid1.Content = midfielders[0];
                lbl_mid2.Content = midfielders[1];
                lbl_mid3.Content = midfielders[2];
                lbl_mid4.Content = midfielders[3];
                cb_mid5.Visibility = Visibility.Hidden;
                cb_mid6.Visibility = Visibility.Hidden;
                lbl_mid5.Visibility = Visibility.Hidden;
                lbl_mid6.Visibility = Visibility.Hidden;
            }
            else if (numOfMidfielders == 5)
            {
                lbl_mid1.Content = midfielders[0];
                lbl_mid2.Content = midfielders[1];
                lbl_mid3.Content = midfielders[2];
                lbl_mid4.Content = midfielders[3];
                lbl_mid5.Content = midfielders[4];
                cb_mid6.Visibility = Visibility.Hidden;
                lbl_mid6.Visibility = Visibility.Hidden;
            }
            else if (numOfMidfielders == 5)
            {
                lbl_mid1.Content = midfielders[0];
                lbl_mid2.Content = midfielders[1];
                lbl_mid3.Content = midfielders[2];
                lbl_mid4.Content = midfielders[3];
                lbl_mid5.Content = midfielders[4];
                lbl_mid6.Content = midfielders[5];
            }
            #endregion

            #region Forwards
            if (numOfForwards == 1)
            {
                lbl_away1.Content = forwards[0];
                cb_vsAway3.Visibility = Visibility.Hidden;
                cb_vsAway4.Visibility = Visibility.Hidden;
                cb_away2.Visibility = Visibility.Hidden;
                cb_away3.Visibility = Visibility.Hidden;
                cb_away4.Visibility = Visibility.Hidden;
                lbl_away2.Visibility = Visibility.Hidden;
                lbl_away3.Visibility = Visibility.Hidden;
                lbl_away4.Visibility = Visibility.Hidden;
            }
            else if (numOfForwards == 2)
            {
                lbl_away1.Content = forwards[0];
                lbl_away2.Content = forwards[1];
                cb_away3.Visibility = Visibility.Hidden;
                cb_away4.Visibility = Visibility.Hidden;
                lbl_away3.Visibility = Visibility.Hidden;
                lbl_away4.Visibility = Visibility.Hidden;
            }
            else if (numOfMidfielders == 3)
            {
                lbl_away1.Content = forwards[0];
                lbl_away2.Content = forwards[1];
                lbl_away3.Content = forwards[2];
                cb_away4.Visibility = Visibility.Hidden;
                lbl_away4.Visibility = Visibility.Hidden;
            }
            else if (numOfForwards == 4)
            {
                lbl_away1.Content = forwards[0];
                lbl_away2.Content = forwards[1];
                lbl_away3.Content = forwards[2];
                lbl_away4.Content = forwards[3];
            }
            #endregion
        }
    }
}
