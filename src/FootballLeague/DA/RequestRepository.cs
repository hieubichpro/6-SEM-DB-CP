using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.DA
{
    public class RequestRepository
    {
        private NpgsqlConnection connector;

        public NpgsqlConnection Connector { get => connector; set => connector = value; }
        public RequestRepository(ConnectionArguments args)
        {
            this.connector = new NpgsqlConnection(args.getStringConnection());
            this.connector.Open();
        }

        internal void insertRequestToClub(int id_club, int id_user)
        {
            string query = "insert into requests(id_league, id_club, id_user) values (1, " + id_club + ", " + id_user + ");";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            command.ExecuteNonQuery();
        }

        internal void deleteRequestByIdUser(int idUser)
        {
            string query = "delete from requests where id_user = " + idUser;
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            command.ExecuteNonQuery();
        }

        internal void deleteRequestByIdRequest(int idRequest)
        {
            string query = "delete from requests where id = " + idRequest + ";";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            command.ExecuteNonQuery();
        }

        internal DataTable getAllRequestOfFootballer(int idFootballer)
        {
            string query = "select r.id, r.created_time, c.name"
                           + " from requests r join clubs c on r.id_club = c.id"
                           + " where id_user = " + idFootballer + ";";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            DataTable dttable = new DataTable();
            dttable.Load(reader);
            reader.Close();
            return dttable;
        }

        internal DataTable getAllRequestToLeague(int idLeague)
        {
            string query = "select r.id, r.created_time, c.id as ID_Club, c.name as Club, u.firstname || ' ' || u.lastname as Coach"
                        + " from clubs c join requests r on r.id_club = c.id"
                        + " join users u on r.id_user = u.id"
                        + " where r.id_league = " + idLeague + ";";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            DataTable dttable = new DataTable();
            dttable.Load(reader);
            reader.Close();
            return dttable;
        }

        internal void insertRequestToLeague(int id_league, int id_club, int id_user)
        {
            string query = "insert into requests(id_league, id_club, id_user) values (" + id_league + ", " + id_club + ", " + id_user + ");";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            command.ExecuteNonQuery();
        }

        internal DataTable getAllRequestToClub(int idClub)
        {
            string query = "select r.id, r.created_time, u.firstname || ' ' || u.lastname as Footballer, u.age as Age"
                        + " from requests r"
                        + " join users u on r.id_user = u.id"
                        + " where id_league = 1 and r.id_club = " + idClub + ";";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            DataTable dttable = new DataTable();
            dttable.Load(reader);
            reader.Close();
            return dttable;
        }
    }
}
