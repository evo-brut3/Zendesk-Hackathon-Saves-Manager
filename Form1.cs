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
            string databaseLocation = "database.txt";
            if (!File.Exists(databaseLocation))
                File.Create("database.txt").Dispose();

            LoadDatabase(databaseLocation);
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
        }

        private void LoadIntoForm()
        {
            List<Profile> profiles = ProfileManager.GetProfileList();

            foreach (var p in profiles)
            {
                gameListView.Items.Add(p.game_name);
                Debug.WriteLine(p.game_id);
                Debug.WriteLine(p.profile_id);
                Debug.WriteLine(p.game_name);
                Debug.WriteLine(p.profile_name);
                Debug.WriteLine(p.profile_location);
            }
        }

        private void Addgame_Click(object sender, EventArgs e)
        {


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
        }

        static class ProfileManager
        {
            public static List<Profile> ProfileList = new List<Profile>();

            public static List<Profile> GetProfileList()
            {
                return ProfileList;
            }

            public static void AddToProfileList(Profile profile)
            {
                ProfileList.Add(profile);
            }

            public static void RemoveFromProfileList()
            {

            }
        }

        private void Profile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
