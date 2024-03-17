using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace FootballLeague.DA
{
    public class Connecter
    {
        private static Connecter instance; //ctrl + R + E

        public static Connecter Instance 
        {
            get
            {
                if (instance == null)
                    instance = new Connecter();
                return instance;
            }
            private set { Connecter.instance = value; }
        }
        private string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=123456789;Database=myDB";
        //private Connecter();

        public DataTable ExecuteQuery(string query)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            DataTable data = new DataTable();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }
    }
}
