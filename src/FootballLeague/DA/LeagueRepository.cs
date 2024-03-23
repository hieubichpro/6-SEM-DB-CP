using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace FootballLeague.DA
{
    public class LeagueRepository
    {
        private NpgsqlConnection connector;
        public NpgsqlConnection Connector { get => connector; set => connector = value; }
        public LeagueRepository(ConnectionArguments args)
        {
            this.connector = new NpgsqlConnection(args.getStringConnection());
            this.connector.Open();
        }

        public void insertLeague(string name, string rating, int idUser, int idCountry)
        {
            string query = "insert into leagues(name, rating, id_user, id_country) values ('" + name + "', " + rating + ", " + idUser + ", " + idCountry + ");";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            command.ExecuteNonQuery();
        }
    }
}
