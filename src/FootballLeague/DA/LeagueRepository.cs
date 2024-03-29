using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
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

        internal void insertIntoTableLeagueClub(int idLeague, int idClub)
        {
            string query = "insert into leagueclub(id_league, id_club) values (" + idLeague + ", " + idClub + ");";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            command.ExecuteNonQuery();
        }

        internal DataTable getAllLeagueInfo()
        {
            string query = "select l.id, l.name as League, l.rating, u.firstname || ' ' || u.lastname as Creator, c.name as Country"
             + " from leagues l join users u on l.id_user = u.id"
             + " join countries c on l.id_country = c.id";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            DataTable dttable = new DataTable();
            dttable.Load(reader);
            reader.Close();
            return dttable;
        }
    }
}
