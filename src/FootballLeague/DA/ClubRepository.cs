using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballLeague.BL.IRepositories;
using Models;
using Npgsql;

namespace FootballLeague.DA
{
    public class ClubRepository : IClubRepository
    {
        public Club readbyName(string name)
        {
            string query = "select * from clubs where name = '" + name + "';";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            reader.Read();
            Club curr = null;
            if (reader.HasRows)
            {
                curr = new Club(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(0));
            }
            reader.Close();
            return curr;
        }

        public Club readbyId(int id)
        {
            string query = "select * from clubs where id = " + id + ";";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            reader.Read();
            Club curr = new Club(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(0));
            reader.Close();
            return curr;
        }
        public void create(Club club)
        {
            string query = "insert into clubs(name, id_country) values ('" + club.Name + "', " + club.IdCountry + ");";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public DataTable readAllClubs()
        {
            string query = "select c.id, c.name as Name_Club, u.firstname || ' ' || u.lastname as Creator, ct.name as Country "
              + "from clubs c "
              + "join users u on u.id_club = c.id "
              + "join countries ct on c.id_country = ct.id "
              + "where u.role = 'Coach';";
            return DataProvider.Instance.getDataTable(query);
        }
        public DataTable readbyIdUserAndRole(int idUser, string role)
        {
            string query = "select cl.id, cl.name as Name_Club, c.name as Country"
                + " from clubs cl join users u on u.id_club = cl.id"
                + " join countries c on cl.id_country = c.id"
                + " where u.id = " + idUser + " and u.role = '" + role + "';";
            return DataProvider.Instance.getDataTable(query);
        }

        public List<int> readAllClubByIdLeague(int id_league)
        {
            string query = "select id_club from leagueclub where id_league = " + id_league;
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            List<int> res = new List<int>();
            while(reader.Read())
            {
                res.Add(reader.GetInt32(0));
            }
            reader.Close();
            return res;
        }
    }
}
