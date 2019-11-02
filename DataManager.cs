using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Zendesk_Hackathon_Saves_Manager
{
    public class Game
    {
        public int game_id;
        public string game_name;
        public string game_save_location;

        public Game(int gid, string gn, string gsl)
        {
            game_id = gid;
            game_name = gn;
            game_save_location = gsl;
        }

        public override string ToString()
        {
            return this.game_name;

        }
    }

    public class Profile
    {
        public int profile_id;
        public string profile_name;
        public int game_id;
        public string profile_save_location;
        bool is_used;

        public Profile(int pid, string pn, int gid, string psl, bool iu)
        {
            profile_id = pid;
            profile_name = pn;
            game_id = gid;
            profile_save_location = psl;
            is_used = iu;
        }

        public override string ToString()
        {
            return this.profile_name;
        }
    }

    static class DataManager
    {
        private static List<Profile> profileList = new List<Profile>();
        private static List<Game> gamesList = new List<Game>();

        public static void PopulateGames()
        {
            gamesList.Clear();

            SqlDataReader sqlDataReader = DatabaseManager.ExecuteDataReader(@"SELECT GameID,GameName,GameSaveLocation FROM Games");

            while (sqlDataReader.Read())
            {
                int gid = sqlDataReader.GetInt32(0);
                string gn = sqlDataReader.GetString(1).TrimEnd(' ');
                string gsl = sqlDataReader.GetString(2).TrimEnd(' ');

                Game g = new Game(gid, gn, gsl);

                gamesList.Add(g);
            }

            sqlDataReader.Close();
        }

        public static void PopulateProfiles(int gameID)
        {
            profileList.Clear();

            SqlDataReader sqlDataReader = DatabaseManager.ExecuteDataReader(String.Format(
                @"SELECT ProfileID,ProfileName,ProfileSaveLocation,IsUsed
                FROM Profiles 
                WHERE GameID={0}",
                gameID));
            
            while (sqlDataReader.Read())
            {
                int pid = sqlDataReader.GetInt32(0);
                string pn = sqlDataReader.GetString(1).TrimEnd(' ');
                int gid = gameID;
                string psl = sqlDataReader.GetString(2).TrimEnd(' ');
                bool iu = sqlDataReader.GetBoolean(3);
                Profile p = new Profile(pid, pn, gid, psl, iu);
            
                profileList.Add(p);
            }
            
            sqlDataReader.Close();
        }

        public static List<Profile> GetProfiles()
        {
            return profileList;
        }

        public static List<Game> GetGames()
        {
            return gamesList;
        }

        public static int GetLastProfileID()
        {
            if (profileList.Count > 0)
                return profileList[profileList.Count - 1].profile_id;
            else
                return 1;
        }

        public static int GetLastGameID()
        {
            if (gamesList.Count > 0)
                return gamesList[gamesList.Count - 1].game_id;
            else
                return 1;
        }
    }
}
