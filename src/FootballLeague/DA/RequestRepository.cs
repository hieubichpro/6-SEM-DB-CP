using FootballLeague.BL.IRepositories;
using Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.DA
{
    public class RequestRepository : IRequestRepository
    {
        public void create(Request request)
        {
            string query = "insert into requests(id_league, id_club, id_user) values (" + request.IdLeague + ", " + request.IdClub + ", " + request.IdUser + ");";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void delete(Request request)
        {
            string query = "delete from requests where id = " + request.Id + ";";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void update(Request request)
        {

        }
        public Request readbyId(int id)
        {
            string query = "select * from requests where id = " + id + ";";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            reader.Read();
            Request curr = new Request(reader.GetDateTime(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(0));
            reader.Close();
            return curr;
        }
        public List<Request> readbyIdUser(int idUser)
        {
            string query = "select * from requests where id_user = " + idUser + ";";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            List<Request> res = new List<Request>();
            while (reader.Read())
            {
                res.Add(new Request(reader.GetDateTime(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(0)));
            }
            reader.Close();
            return res;
        }
        public List<Request> readByIdClub(int idClub)
        {
            string query = "select * from requests where id_club = " + idClub + ";";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            List<Request> res = new List<Request>();
            while (reader.Read())
            {
                res.Add(new Request(reader.GetDateTime(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(0)));
            }
            reader.Close();
            return res;
        }
        public DataTable readbyIdFootballer(int idFootballer)
        {
            string query = "select r.id, r.created_time, c.name"
               + " from requests r join clubs c on r.id_club = c.id"
               + " where id_user = " + idFootballer + ";";
            return DataProvider.Instance.getDataTable(query);
        }
        public DataTable readbyIdClub(int idClub)
        {
            string query = "select r.id, r.id_user as id_footballer, r.created_time, u.firstname || ' ' || u.lastname as Footballer, u.age as Age"
            + " from requests r"
            + " join users u on r.id_user = u.id"
            + " where id_league = -1 and r.id_club = " + idClub + ";";
            return DataProvider.Instance.getDataTable(query);
        }
        public DataTable readbyIdLeague(int idLeague)
        {
            string query = "select r.id, r.created_time, c.id as ID_Club, c.name as Club, u.firstname || ' ' || u.lastname as Coach"
            + " from clubs c join requests r on r.id_club = c.id"
            + " join users u on r.id_user = u.id"
            + " where r.id_league = " + idLeague + ";";
            return DataProvider.Instance.getDataTable(query);
        }

        //internal void deleteRequestByIdUser(int idUser)
        //{
        //    string query = "delete from requests where id_user = " + idUser;
        //    DataProvider.Instance.ExecuteNonQuery(query);
        //}

        //internal void deleteRequestByIdRequest(int idRequest)
        //{
        //    string query = "delete from requests where id = " + idRequest + ";";
        //    DataProvider.Instance.ExecuteNonQuery(query);
        //}

        //internal DataTable getAllRequestOfFootballer(int idFootballer)
        //{
        //    string query = "select r.id, r.created_time, c.name"
        //                   + " from requests r join clubs c on r.id_club = c.id"
        //                   + " where id_user = " + idFootballer + ";";
        //    return DataProvider.Instance.getDataTable(query);
        //}

        //internal void deleteRequestByIdClub(int idClub)
        //{
        //    string query = "delete from requests where id_club = " + idClub + ";";
        //    DataProvider.Instance.ExecuteNonQuery(query);
        //}

        //internal DataTable getAllRequestToLeague(int idLeague)
        //{
        //    string query = "select r.id, r.created_time, c.id as ID_Club, c.name as Club, u.firstname || ' ' || u.lastname as Coach"
        //                + " from clubs c join requests r on r.id_club = c.id"
        //                + " join users u on r.id_user = u.id"
        //                + " where r.id_league = " + idLeague + ";";
        //    return DataProvider.Instance.getDataTable(query);
        //}

        //internal void insertRequestToLeague(int id_league, int id_club, int id_user)
        //{
        //    string query = "insert into requests(id_league, id_club, id_user) values (" + id_league + ", " + id_club + ", " + id_user + ");";
        //    DataProvider.Instance.ExecuteNonQuery(query);
        //}

        //internal DataTable getAllRequestToClub(int idClub)
        //{
        //    string query = "select r.id, r.created_time, u.firstname || ' ' || u.lastname as Footballer, u.age as Age"
        //                + " from requests r"
        //                + " join users u on r.id_user = u.id"
        //                + " where id_league = 1 and r.id_club = " + idClub + ";";
        //    return DataProvider.Instance.getDataTable(query);
        //}
    }
}
