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

        public Profile(int pid, string pn, int gid)
        {
            profile_id = pid;
            profile_name = pn;
            game_id = gid;
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
                string gn = sqlDataReader.GetValue(1).ToString();
                string gsl = sqlDataReader.GetValue(2).ToString();
                Game g = new Game(gid, gn, gsl);

                gamesList.Add(g);
            }

            sqlDataReader.Close();
        }

        public static void PopulateProfiles(int gameID)
        {
            profileList.Clear();

            SqlDataReader sqlDataReader = DatabaseManager.ExecuteDataReader(String.Format(
                @"SELECT ProfileID,ProfileName 
                FROM Profiles 
                WHERE GameID={0}",
                gameID));
            
            while (sqlDataReader.Read())
            {
                int pid = sqlDataReader.GetInt32(0);
                string pn = sqlDataReader.GetValue(1).ToString();
                int gid = gameID;
                Profile p = new Profile(pid, pn, gid);
            
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
            return profileList[profileList.Count - 1].profile_id;
        }

        public static int GetLastGameID()
        {
            return gamesList[gamesList.Count - 1].game_id;
        }
    }
}
