using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballLeague.BL.IRepositories;
using FootballLeague.Models;
using Models;
using Npgsql;

namespace FootballLeague.DA
{
    public class LeagueRepository : ILeagueRepository
    {
        public League readbyName(string name)
        {
            string query = "select * from leagues where name = '" + name + "';";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            reader.Read();
            League curr = null;
            if (reader.HasRows)
                curr = new League(reader.GetString(1), reader.GetDouble(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(0));
            reader.Close();
            return curr;

        }
        public void create(League league)
        {
            string query = "insert into leagues(name, rating, id_user, id_country) values ('" + league.Name + "', " + league.Rating + ", " + league.IdUser + ", " + league.IdCountry + ");";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public DataTable readAllLeagues()
        {
            string query = "select l.id, l.name as League, round(l.rating::numeric, 2), u.firstname || ' ' || u.lastname as Creator, c.name as Country"
             + " from leagues l join users u on l.id_user = u.id"
             + " join countries c on l.id_country = c.id";
            return DataProvider.Instance.getDataTable(query);
        }
        public DataTable readbyIdUser(int idUser)
        {
            string query = "select l.id, l.name, l.rating, c.name"
            + " from leagues l join countries c on l.id_country = c.id"
            + " where id_user = " + idUser + ";";
            return DataProvider.Instance.getDataTable(query);
        }

        public void createOnCLTable(ClubLeague clubLeague)
        {
            string query = "insert into leagueclub(id_league, id_club) values (" + clubLeague.IdLeague + ", " + clubLeague.IdClub + ");";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public bool readByIdUser(int idUSer)
        {
            string query = "select * from leagues where id_user = " + idUSer + ";";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            bool res = false;
            reader.Read();
            if (reader.HasRows)
                res = true;
            reader.Close();
            return res;
        }

        public DataTable readTable(int id_league)
        {
            string query = "select * from get_table_league(" + id_league + ");";
            return DataProvider.Instance.getDataTable(query);
        }

        public void schedule(int id_league)
        {
            string query = "select create_schedule(" + id_league + ")";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void deleteById(int id_league)
        {
            string query = "delete from leagues where id = " + id_league;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
