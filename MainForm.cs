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

            string gn = addGameForm.GetNameAndLocation.Item1;
            string gsl = addGameForm.GetNameAndLocation.Item2;

            //// ERROR HANDLING
            /// if gsl is empty then throw

            if (gsl.Last().ToString() == "\\")
                gsl = gsl.Remove(gsl.Length - 1);

            string command = String.Format(
                "INSERT INTO Games (GameName, GameSaveLocation) VALUES (\'{0}\', \'{1}\')",
                gn,
                gsl);

            DatabaseManager.AddToDatabase(command);

            RefreshGames();
            AddNewProfile(DataManager.GetLastGameID(), true);
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

        private void AddNewProfile(int gameID, bool isUsed)
        {
            AddProfileForm addProfileForm = new AddProfileForm();
            addProfileForm.ShowDialog();

            SqlDataReader sqlDataReader = DatabaseManager.ExecuteDataReader(String.Format(
                @"SELECT GameSaveLocation
                FROM Games 
                WHERE GameID={0}",
                gameID));

            string gameSaveLocation = "";
            while (sqlDataReader.Read())
            {
              gameSaveLocation = sqlDataReader.GetValue(0).ToString().TrimEnd(' ');
            }
            string profileSaveLocation = gameSaveLocation + "_" + addProfileForm.GetProfileName;

            sqlDataReader.Close();

            string command = String.Format(
                "INSERT INTO Profiles (ProfileName, GameID, ProfileSaveLocation, IsUsed) VALUES (\'{0}\', {1}, \'{2}\', {3})",
                addProfileForm.GetProfileName,
                gameID,
                profileSaveLocation,
                (isUsed ? 1 : 0));

            DatabaseManager.AddToDatabase(command);

            FSManager.DirectoryCopy(gameSaveLocation, profileSaveLocation, true);
            RefreshProfiles();
        }

        private void Addprofile_Click(object sender, EventArgs e)
        {
            if (gameListView.SelectedItems.Count > 0)
            {
                Game selectedGame = gameListView.SelectedItem as Game;
                AddNewProfile(selectedGame.game_id, false);
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

        private void ProfileListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Profile profile = profileListView.SelectedItem as Profile;
            Game game = gameListView.SelectedItem as Game;

            SqlDataReader sqlDataReader = DatabaseManager.ExecuteDataReader(String.Format(
                @"SELECT ProfileName,ProfileID
                FROM Profiles
                WHERE IsUsed=1"));

            string lastProfileName = "";
            int profileID = 0;
            while (sqlDataReader.Read())
            {
                lastProfileName = sqlDataReader.GetString(0).TrimEnd(' ');
                profileID = sqlDataReader.GetInt32(1);
            }
            sqlDataReader.Close();

            FSManager.DirectoryRename(game.game_save_location, game.game_save_location + "_" + lastProfileName);

            DatabaseManager.UpdateDatabase(String.Format(
                "UPDATE Profiles SET ProfileSaveLocation=\'{0}\' WHERE ProfileID={1}",
                game.game_save_location + "_" + lastProfileName,
                profileID));

            DatabaseManager.UpdateDatabase(String.Format(
            @"UPDATE Profiles 
                SET IsUsed=0
                WHERE ProfileID={0}",
                profileID));

            RefreshProfiles();
            FSManager.DirectoryRename(profile.profile_save_location, game.game_save_location);

            DatabaseManager.UpdateDatabase(String.Format(
                "UPDATE Profiles SET ProfileSaveLocation=\'{0}\' WHERE ProfileID={1}",
                game.game_save_location,
                game.game_id));

            DatabaseManager.UpdateDatabase(String.Format(
                @"UPDATE Profiles 
                SET IsUsed=1
                WHERE ProfileID={0}",
                profile.profile_id));
        }
    }
}
