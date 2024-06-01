using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using FootballLeague.BL.IRepositories;

namespace FootballLeague.DA
{
    public class CountryRepository : ICountryRepository
    {
        public List<Country> readAllCountries()
        {
            string query = "select * from countries";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            List<Country> allCountries = new List<Country>();
            while (reader.Read())
            {
                allCountries.Add(new Country(reader.GetString(1), reader.GetString(2), reader.GetInt32(0)));
            }
            reader.Close();
            return allCountries;
        }
        public Country readbyName(string name)
        {
            string query = "select * from countries where name = '" + name + "';";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            reader.Read();
            Country curr = new Country(reader.GetString(1), reader.GetString(2), reader.GetInt32(0));
            reader.Close();
            return curr;
        }
    }
}
