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
    public class StadiumRepository : IStadiumRepository
    {
        public DataTable readAllStadium()
        {
            string query = "select s.id, s.name, s.capacity, c.name as country"
                         + " from stadiums s join countries c on s.id_country = c.id";
            return DataProvider.Instance.getDataTable(query);
        }
        public Stadium readbyName(string name)
        {
            string query = "select * from stadiums where name = '" + name + "';";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            reader.Read();
            Stadium stadium = null;
            if (reader.HasRows)
            {
                stadium = new Stadium(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(0));
            }
            reader.Close();
            return stadium;
        }
        public Stadium readbyId(int id)
        {
            string query = "select * from stadiums where id = " + id + ";";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            reader.Read();
            Stadium stadium = new Stadium(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(0));
            reader.Close();
            return stadium;
        }
        public void create(Stadium stadium)
        {
            string query = "insert into stadiums(name, capacity, id_country) values ('" + stadium.Name + "', " + stadium.Capacity + ", " + stadium.IdCountry + ");";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void update(Stadium stadium)
        {
            string query = "update stadiums set name = '" + stadium.Name + "', capacity = " + stadium.Capacity + ", id_country = " + stadium.IdCountry + " where id = " + stadium.Id + ";";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void delete(Stadium stadium)
        {
            string query = "delete from stadiums where id = " + stadium.Id + ";";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public List<int> readAllId()
        {
            string query = "select id from stadiums";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            List<int> res = new List<int>();
            while (reader.Read())
                res.Add(reader.GetInt32(0));
            reader.Close();
            return res;
        }
    }
}
