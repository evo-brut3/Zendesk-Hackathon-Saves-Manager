using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Zendesk_Hackathon_Saves_Manager
{
    static class DatabaseManager
    {
        private static SqlConnection sqlConnection;
        private static SqlCommand sqlCommand;
        private static SqlDataReader sqlDataReader;
        private static SqlDataAdapter sqlDataAdapter;
        private static string connectionString;

        public static void Connect()
        {
            connectionString =
                @"Data Source=LAPTOP-RNMENMQ9;
                Initial Catalog=ProfilesDB;
                Integrated Security=True;
                Pooling=False";

            sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();
            MessageBox.Show("Connection Open !");
        }

        public static void Disconnect()
        {
            sqlDataReader.Close();
            sqlCommand.Dispose();
            sqlConnection.Close();
        }

        public static SqlDataReader ExecuteDataReader(string command)
        {
            sqlCommand = new SqlCommand(command, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();

            return sqlDataReader;
        }

        public static void AddToDatabase(string command)
        {
            sqlDataAdapter = new SqlDataAdapter();
            sqlCommand = new SqlCommand(command, sqlConnection);

            sqlDataAdapter.InsertCommand = new SqlCommand(command, sqlConnection);
            sqlDataAdapter.InsertCommand.ExecuteNonQuery();
            sqlDataAdapter.Dispose();
        }

        public static void UpdateDatabase(string command)
        {
            sqlDataAdapter = new SqlDataAdapter();
            sqlCommand = new SqlCommand(command, sqlConnection);

            sqlDataAdapter.UpdateCommand = new SqlCommand(command, sqlConnection);
            sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
            sqlDataAdapter.Dispose();
        }

        public static void DeleteFromDatabase(string command)
        {
            sqlDataAdapter = new SqlDataAdapter();
            sqlCommand = new SqlCommand(command, sqlConnection);

            sqlDataAdapter.DeleteCommand = new SqlCommand(command, sqlConnection);
            sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
            sqlDataAdapter.Dispose();
        }
    }
}
