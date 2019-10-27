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

namespace Zendesk_Hackathon_Saves_Manager
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            if (!File.Exists(Globals.DATABASE_LOCATION))
                File.Create(Globals.DATABASE_LOCATION).Dispose();

            LoadDatabase(Globals.DATABASE_LOCATION);
            LoadIntoForm();
        }

        private static void LoadDatabase(string location)
        {
            string[] lines = File.ReadAllLines(location);

            foreach (string line in lines)
            {
                string[] prof = line.Split(';');
                string[] id = prof[0].Split('.');

                Profile profile = new Profile(int.Parse(id[0]), int.Parse(id[1]), prof[1], prof[2], prof[3]);

                ProfileManager.AddToProfileList(profile);
            }

            SaveDatabase(Globals.DATABASE_LOCATION);
        }

        public static void SaveDatabase(string location)
        {
            if (!File.Exists(Globals.DATABASE_LOCATION))
                File.Create(Globals.DATABASE_LOCATION).Dispose();

            ProfileManager.SortProfiles();

            using (StreamWriter sw = File.CreateText(Globals.DATABASE_LOCATION))
            {
                foreach (Profile profile in ProfileManager.GetProfileList())
                {
                    sw.WriteLine(profile.game_id + "." + profile.profile_id + ";" + profile.game_name + ";" + profile.profile_name + ";" + profile.profile_location);
                }
            }
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

        private void LoadIntoForm()
        {
            List<Profile> profiles = ProfileManager.GetProfileList();

            foreach (var p in profiles)
            {
                if (p.profile_id == 1)
                    gameListView.Items.Add(p);
            }
        }

        private void Addgame_Click(object sender, EventArgs e)
        {
            Form3 addGameForm = new Form3();
            addGameForm.ShowDialog();

            string[] nameAndLocation = addGameForm.GetNameAndLocation.Split(';');
            List<Profile> profiles = ProfileManager.GetProfileList();

            bool profileAlreadyExists = false;
            foreach (Profile profile in profiles)
            {
                if (nameAndLocation[1] == profile.profile_location.Remove(profile.profile_location.LastIndexOf("_")))
                {
                    profileAlreadyExists = true;
                }
            }

            if (profileAlreadyExists == false)
            {
                if (profiles.Count == 0)
                {
                    Profile p = new Profile(1, 1, nameAndLocation[0], "Default", nameAndLocation[1] + "_1.1");

                    ProfileManager.AddToProfileList(p);

                    DirectoryCopy(nameAndLocation[1], nameAndLocation[1] + "_1.1", true);
                }
                else
                {
                    int lastGameID = profiles[profiles.Count - 1].game_id + 1;
                    Profile p = new Profile(lastGameID, 1, nameAndLocation[0], "Default", nameAndLocation[1] + "_" + lastGameID + ".1");

                    ProfileManager.AddToProfileList(p);

                    DirectoryCopy(nameAndLocation[1], nameAndLocation[1] + "_" + lastGameID + ".1", true);
                }
            }
        }
        public class Profile
        {
            public int game_id;
            public int profile_id;
            public string game_name;
            public string profile_name;
            public string profile_location;

            public Profile(int gid, int pid, string gn, string pn, string pl)
            {
                game_id = gid;
                profile_id = pid;
                game_name = gn;
                profile_name = pn;
                profile_location = pl;
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

        static class ProfileManager
        {
            private static List<Profile> ProfileList = new List<Profile>();

            public static List<Profile> GetProfileList()
            {
                return ProfileList;
            }

            public static void AddToProfileList(Profile profile)
            {
                ProfileList.Add(profile);
                SaveDatabase(Globals.DATABASE_LOCATION);
            }

            public static void RemoveFromProfileList()
            {

            }

            public static List<Profile> SearchForGameID(int gameID)
            {
                List<Profile> searchedProfiles = new List<Profile>();

                foreach (var profile in ProfileList)
                {
                    if (profile.game_id == gameID)
                    {
                        searchedProfiles.Add(profile);
                    }
                }

                return searchedProfiles;
            }

            public static void SortProfiles()
            {
                ProfileList.Sort((x, y) => x.game_id.CompareTo(y.game_id));
            }
        }

        private void Profile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GameListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gameListView.SelectedItems.Count > 0)
            {
                profileListView.Items.Clear();

                Profile selectedGame = gameListView.SelectedItem as Profile;
                List<Profile> searchedProfiles = ProfileManager.SearchForGameID(selectedGame.game_id);

                foreach(Profile profile in searchedProfiles)
                {
                    profileListView.Items.Add(profile.profile_name);
                }
                
            }
        }

        private void Addprofile_Click(object sender, EventArgs e)
        {
            if (gameListView.SelectedItems.Count > 0)
            {
                Form4 addProfileForm = new Form4();
                addProfileForm.ShowDialog();

                int newGameID = 0;
                int newProfileID = 0;
                string newGameName = gameListView.SelectedItem.ToString();
                string newProfileName = addProfileForm.GetProfileName;
                string newProfileLocation = "";

                newProfileName = addProfileForm.GetProfileName;
                List<Profile> profiles = ProfileManager.GetProfileList();

                foreach (Profile profile in profiles)
                {
                    if (profile.game_name == newGameName)
                    {
                        newGameID = profile.game_id;
                        newProfileLocation = profile.profile_location.Remove(profile.profile_location.LastIndexOf("_")) + "_" + profile.game_id.ToString() + ".";
                        break;
                    }
                }

                List<Profile> profilesWithSpecificGameID = ProfileManager.SearchForGameID(newGameID);

                newProfileID = profilesWithSpecificGameID[profilesWithSpecificGameID.Count-1].profile_id + 1;
                newProfileLocation += newProfileID;

                Profile p = new Profile(newGameID, newProfileID, newGameName, newProfileName, newProfileLocation);

                ProfileManager.AddToProfileList(p);
                var newProfLoc = newProfileLocation.Remove(newProfileLocation.LastIndexOf("_"));
                DirectoryCopy(newProfLoc, newProfLoc + "_" + newGameID + "." + newProfileID, true);
            }
        }
    }
}
