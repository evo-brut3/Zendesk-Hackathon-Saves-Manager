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
            PopulateGames();
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void PopulateGames()
        {
            gameListView.Items.Clear();

            SqlDataReader sqlDataReader = DatabaseManager.ExecuteDataReader("SELECT GameID,GameName FROM Games");

            while (sqlDataReader.Read())
            {
                int gid = Int32.Parse(sqlDataReader.GetValue(0).ToString());
                string gn = sqlDataReader.GetValue(1).ToString();
                Game p = new Game(gid, gn);

                gameListView.Items.Add(p);
            }

            sqlDataReader.Close();
        }

        private void PopulateProfiles()
        {
            if (gameListView.SelectedItems.Count > 0)
            {
                profileListView.Items.Clear();

                Game selectedGame = gameListView.SelectedItem as Game;
                SqlDataReader sqlDataReader = DatabaseManager.ExecuteDataReader(String.Format(
                    @"SELECT ProfileID,ProfileName 
                    FROM Profiles 
                    WHERE Game = {0}",
                    selectedGame.game_id));

                while (sqlDataReader.Read())
                {
                    profileListView.Items.Add(sqlDataReader.GetValue(1).ToString());
                }

                sqlDataReader.Close();
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
            PopulateGames();
        }

        public class Game
        {
            public int game_id;
            public string game_name;

            public Game(int gid, string gn)
            {
                game_id = gid;
                game_name = gn;
            }

            public override string ToString()
            {
                return this.game_name;

            }
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
            PopulateProfiles();
        }

        private void Addprofile_Click(object sender, EventArgs e)
        {
            if (gameListView.SelectedItems.Count > 0)
            {
                Game selectedGame = gameListView.SelectedItem as Game;

                AddProfileForm addProfileForm = new AddProfileForm();
                addProfileForm.ShowDialog();

                string command = String.Format(
                    "INSERT INTO Profiles (ProfileName, Game) VALUES (\'{0}\', {1})", 
                    addProfileForm.GetProfileName, 
                    selectedGame.game_id);

                DatabaseManager.AddToDatabase(command);
                PopulateProfiles();
                //DirectoryCopy(newProfLoc, newProfLoc + "_" + newGameID + "." + newProfileID, true);
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
                Game selectedGame = gameListView.SelectedItem as Game;

                string rmGameCommand = String.Format(
                    "DELETE Games WHERE GameID={0}",
                    selectedGame.game_id);

                DatabaseManager.DeleteFromDatabase(rmGameCommand);

                string rmProfilesCommand = String.Format(
                "DELETE Profiles WHERE Game={0}",
                selectedGame.game_id);

                DatabaseManager.DeleteFromDatabase(rmProfilesCommand);
            }

            PopulateGames();
            profileListView.Items.Clear();
        }
    }
}
