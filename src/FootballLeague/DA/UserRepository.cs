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
    public class UserRepository
    {
        private NpgsqlConnection connector;
        public NpgsqlConnection Connector { get => connector; set => connector = value; }
        public UserRepository(ConnectionArguments args)
        {
            this.connector = new NpgsqlConnection(args.getStringConnection());
            this.connector.Open();
        }
        public bool Login(string username, string password)
        {
            string query = "select * from users where login = '" + username + "' and password = '" + password + "'";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            dynamic n = reader.HasRows;
            reader.Close();
            return n ? true : false;
        }

        public void Register(string username, string password, string role, string firstname, string lastname, string age)
        {
            string query = "insert into users(login, password, role, firstname, lastname, age) values ('" + username + "', '" + password + "', '" + role + "', '" + firstname + "', '" + lastname + "', " + age + ");";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            command.ExecuteNonQuery();
        }

        internal void updateIdClubOfUser(int idUser, int idClub)
        {
            string query = "update users set id_club = " + idClub + " where id = " + idUser + ";";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            command.ExecuteNonQuery();
        }

        internal void ChangeInfoUser(string username, string firstname, string lastname, string age)
        {
            string query = "update users set firstname = '" + firstname + "', lastname = '" + lastname + "', age = " + age + " where login = '" + username + "';";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            command.ExecuteNonQuery();
        }

        internal DataTable getAllFootballerInClub(int idClub)
        {
            string query = "select u.id, u.firstname as FirstName, u.lastname as LastName, u.age as Age"
                           + " from clubs c join users u on u.id_club = c.id"
                           + " where u.role = 'Footballer' and c.id = " + idClub + ";";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            DataTable dttable = new DataTable();
            dttable.Load(reader);
            reader.Close();
            return dttable;
        }

        internal User getUserByUsername(string username)
        {
            string query = "select * from users where login = '" + username + "';";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            User curr = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6));
            reader.Close();
            return curr;
        }

        public void ChangePassword(string username, string password)
        {
            string query = "update users set password = '" + password + "' where login = '" + username + "';";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            command.ExecuteNonQuery();
        }

        public List<User> getUserByRole(string role)
        {
            string query = "select * from users where role = '" + role + "';";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            List<User> res = new List<User>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    res.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6)));
                }
            }
            reader.Close();
            return res;
        }

        public DataTable getAllUserAndInfoByRole(string role)
        {
            string query = "select u.id, u.firstname || ' ' || u.lastname as Fullname_Footballer, u.age, c.name as Name_Club"
                         + " from users u left join clubs c"
                         + " on u.id_club = c.id"
                         + " where role = '" + role + "';";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            DataTable dttable = new DataTable();
            dttable.Load(reader);
            reader.Close();
            return dttable;
        }
    }
}
