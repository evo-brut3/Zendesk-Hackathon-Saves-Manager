using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;

namespace Zendesk_Hackathon_Saves_Manager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            if (!File.Exists(Globals.DATABASE_LOCATION))
                File.Create(Globals.DATABASE_LOCATION).Dispose();

            DatabaseManager.Connect();
            RefreshProfiles();
            RefreshGames();
        }

        private void RefreshProfiles()
        {
            List<Profile> profilesList = DataManager.GetProfiles();
            profileListView.Items.Clear();

            if (gameListView.Items.Count > 0)
            {
                Game selectedGame;
                if (gameListView.SelectedItem != null)
                    selectedGame = gameListView.SelectedItem as Game;
                else
                    selectedGame = gameListView.Items[0] as Game;

                DataManager.PopulateProfiles(selectedGame.game_id);
            }

            foreach (Profile p in profilesList)
            {
                profileListView.Items.Add(p);
            }
        }

        private void RefreshGames()
        {
            gameListView.Items.Clear();
            DataManager.PopulateGames();
            List<Game> gamesList = DataManager.GetGames();

            foreach (Game g in gamesList)
            {
                gameListView.Items.Add(g);
            }
        }

        private void Addgame_Click(object sender, EventArgs e)
        {
            AddGameForm addGameForm = new AddGameForm();
            addGameForm.ShowDialog();

            string command = String.Format(
                "INSERT INTO Games (GameName, GameSaveLocation) VALUES (\'{0}\', \'{1}\')",
                addGameForm.GetNameAndLocation.Item1,
                addGameForm.GetNameAndLocation.Item2);

            DatabaseManager.AddToDatabase(command);

            AddNewProfile(DataManager.GetLastGameID());
            RefreshGames();
            RefreshProfiles();
        }

        static class Globals
        {
            public static string DATABASE_LOCATION = "database.txt";
        }

        private void Profile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GameListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshProfiles();
        }

        private void AddNewProfile(int gameID)
        {
            AddProfileForm addProfileForm = new AddProfileForm();
            addProfileForm.ShowDialog();

            string command = String.Format(
                "INSERT INTO Profiles (ProfileName, GameID) VALUES (\'{0}\', {1})",
                addProfileForm.GetProfileName,
                gameID);

            DatabaseManager.AddToDatabase(command);

            //string copyFrom = "";
            //string copyTo =

            //FSManager.DirectoryCopy(addProfileForm.GetProfileName, GetProfileName + "_" + newGameID + "." + newProfileID, true);
            RefreshProfiles();
        }

        private void Addprofile_Click(object sender, EventArgs e)
        {
            if (gameListView.SelectedItems.Count > 0)
            {
                Game selectedGame = gameListView.SelectedItem as Game;
                AddNewProfile(selectedGame.game_id);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DatabaseManager.Disconnect();
        }

        private void Deletegame_Click(object sender, EventArgs e)
        {
            if (gameListView.SelectedItems.Count > 0)
            {
                DeleteGameForm deleteGameForm = new DeleteGameForm();
                deleteGameForm.ShowDialog();

                if (deleteGameForm.CheckTheAnswer == true)
                {
                    Game selectedGame = gameListView.SelectedItem as Game;

                    string rmGameCommand = String.Format(
                        "DELETE Games WHERE GameID={0}",
                        selectedGame.game_id);

                    DatabaseManager.DeleteFromDatabase(rmGameCommand);

                    string rmProfilesCommand = String.Format(
                    "DELETE Profiles WHERE GameID={0}",
                    selectedGame.game_id);

                    DatabaseManager.DeleteFromDatabase(rmProfilesCommand);
                    RefreshProfiles();
                    RefreshGames();
                }
            }
        }

        private void Deleteprofile_Click(object sender, EventArgs e)
        {
            if (profileListView.SelectedItems.Count > 0)
            {
                DeleteProfile deleteProfile = new DeleteProfile();
                deleteProfile.ShowDialog();

                if (deleteProfile.CheckTheAnswer == true)
                {
                    Profile selectedProfile = profileListView.SelectedItem as Profile;

                    string rmProfileCommand = String.Format(
                    "DELETE Profiles WHERE ProfileID={0}",
                    selectedProfile.profile_id);

                    DatabaseManager.DeleteFromDatabase(rmProfileCommand);
                    RefreshProfiles();
                }
            }
        }
    }
}
