using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace FootballLeague.DA
{
    public class CountryRepository
    {
        private NpgsqlConnection connector;
        public NpgsqlConnection Connector { get => connector; set => connector = value; }

        public CountryRepository(ConnectionArguments args)
        {
            this.Connector = new NpgsqlConnection(args.getStringConnection());
            this.Connector.Open();
        }


        internal List<Country> getAllCountries()
        {
            string query = "select * from countries";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            List<Country> allCountries = new List<Country>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    allCountries.Add(new Country(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
            }
            reader.Close();
            return allCountries;
        }

        internal Country getCountryByName(string name)
        {
            string query = "select * from countries where name = '" + name + "';";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Country curr = new Country(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            reader.Close();
            return curr;
        }
    }
}
