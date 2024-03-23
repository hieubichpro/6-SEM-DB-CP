using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.DA
{
    public class StadiumRepository
    {
        private NpgsqlConnection connector;

        public NpgsqlConnection Connector { get => connector; set => connector = value; }
        public StadiumRepository(ConnectionArguments args)
        {
            this.connector = new NpgsqlConnection(args.getStringConnection());
            this.connector.Open();
        }

        internal DataTable getAllStadiumInfo()
        {
            string query = "select s.id, s.name, s.capacity, c.name as country"
                         + " from stadiums s join countries c on s.id_country = c.id";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            DataTable dttable = new DataTable();
            dttable.Load(reader);
            reader.Close();
            return dttable;
        }

        internal void deleteStadiumById(int id)
        {
            string query = "delete from stadiums where id = " + id + ";";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            command.ExecuteNonQuery();
        }

        internal void insertStadium(string name, string capacity, int idCountry)
        {
            string query = "insert into stadiums(name, capacity, id_country) values ('" + name + "', " + capacity + ", " + idCountry + ");";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            command.ExecuteNonQuery();

        }
    }
}
