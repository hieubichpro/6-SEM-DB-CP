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
    public class UserRepository : IUserRepository
    {
        public User readById(int id)
        {
            string query = "select * from users where id = " + id + ";";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            reader.Read();
            User curr = null;
            if (reader.HasRows)
            {
                curr = new User(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(0));
            }
            reader.Close();
            return curr;
        }
        public User readByLogin(string login)
        {
            string query = "select * from users where login = '" + login + "';";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            reader.Read();
            User curr = null;
            if (reader.HasRows)
            {
                curr = new User(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(0));
            }
            reader.Close();
            return curr;
        }
        public List<User> readByRole(string role)
        {
            string query = "select * from users where role = '" + role + "';";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            List<User> res = new List<User>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    res.Add(new User(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(0)));
                }
            }
            reader.Close();
            return res;

        }
        public void create(User user)
        {
            string query = "insert into users(login, password, role, firstname, lastname, age) values ('" + user.Login + "', '" + user.Password + "', '" + user.Role + "', '" + user.FirstName + "', '" + user.LastName + "', " + user.Age + ");";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void update(User user)
        {
            string query = "update users set login = '" + user.Login + "', " + " firstname = '" + user.FirstName + "', lastname = '" + user.LastName + "', password = '" + user.Password + "', id_club = " + user.IdClub + " where id = " + user.Id + ";";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public DataTable readAllFootballer(int idClub)
        {
            string query = "select u.id, u.firstname as FirstName, u.lastname as LastName, u.age as Age"
                           + " from clubs c join users u on u.id_club = c.id"
                           + " where u.role = 'Footballer' and c.id = " + idClub + ";";
            return DataProvider.Instance.getDataTable(query);
        }

        public DataTable readAllUserByRole(string role)
        {
            string query = "select u.id, u.firstname || ' ' || u.lastname as Fullname, u.age, c.name as Club"
                         + " from users u left join clubs c"
                         + " on u.id_club = c.id"
                         + " where role = '" + role + "';";
            return DataProvider.Instance.getDataTable(query);
        }

        public DataTable readAllUser()
        {
            string query = "select * from users where role != 'Admin'";
            return DataProvider.Instance.getDataTable(query);
        }

        public void delete(int id)
        {
            string query = "delete from users where id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        //public bool Login(string username, string password)
        //{
        //    string query = "select * from users where login = '" + username + "' and password = '" + password + "'";
        //    NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
        //    NpgsqlDataReader reader = command.ExecuteReader();
        //    dynamic n = reader.HasRows;
        //    reader.Close();
        //    return n ? true : false;
        //}

        //public void Register(string username, string password, string role, string firstname, string lastname, string age)
        //{

        //}

        //internal void updateIdClubOfUser(int idUser, int idClub)
        //{
        //    string query = "update users set id_club = " + idClub + " where id = " + idUser + ";";
        //    NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
        //    command.ExecuteNonQuery();
        //}

        //internal void ChangeInfoUser(string username, string firstname, string lastname, string age)
        //{
        //    string query = "update users set firstname = '" + firstname + "', lastname = '" + lastname + "', age = " + age + " where login = '" + username + "';";
        //    NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
        //    command.ExecuteNonQuery();
        //}

        //internal DataTable getAllFootballerInClub(int idClub)
        //{
        //    string query = "select u.id, u.firstname as FirstName, u.lastname as LastName, u.age as Age"
        //                   + " from clubs c join users u on u.id_club = c.id"
        //                   + " where u.role = 'Footballer' and c.id = " + idClub + ";";
        //    NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
        //    NpgsqlDataReader reader = command.ExecuteReader();
        //    DataTable dttable = new DataTable();
        //    dttable.Load(reader);
        //    reader.Close();
        //    return dttable;
        //}

        //internal User getUserByUsername(string username)
        //{
        //    string query = "select * from users where login = '" + username + "';";
        //    NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
        //    NpgsqlDataReader reader = command.ExecuteReader();
        //    reader.Read();
        //    User curr = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetInt32(7));
        //    reader.Close();
        //    return curr;
        //}

        //public void ChangePassword(string username, string password)
        //{
        //    string query = "update users set password = '" + password + "' where login = '" + username + "';";
        //    NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
        //    command.ExecuteNonQuery();
        //}

        //public List<User> getUserByRole(string role)
        //{
        //    string query = "select * from users where role = '" + role + "';";
        //    NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
        //    NpgsqlDataReader reader = command.ExecuteReader();
        //    List<User> res = new List<User>();
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            res.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6)));
        //        }
        //    }
        //    reader.Close();
        //    return res;
        //}

        //public DataTable getAllUserAndInfoByRole(string role)
        //{
        //    string query = "select u.id, u.firstname || ' ' || u.lastname as Fullname_Footballer, u.age, c.name as Name_Club"
        //                 + " from users u left join clubs c"
        //                 + " on u.id_club = c.id"
        //                 + " where role = '" + role + "';";
        //    NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
        //    NpgsqlDataReader reader = command.ExecuteReader();
        //    DataTable dttable = new DataTable();
        //    dttable.Load(reader);
        //    reader.Close();
        //    return dttable;
        //}
    }
}
