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
    public class ClubRepository
    {
        private NpgsqlConnection connector;

        public NpgsqlConnection Connector { get => connector; set => connector = value; }
        public ClubRepository(ConnectionArguments args)
        {
            this.connector = new NpgsqlConnection(args.getStringConnection());
            this.connector.Open();
        }

        public void insertClub(string name, int idUser, int idCountry)
        {
            string query = "insert into clubs(name, id_country) values ('" + name + "', " + idCountry + ");";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            command.ExecuteNonQuery();
        }

        public DataTable getAllClubAndInfo()
        {
            string query = "select c.id, c.name as Name_Club, u.firstname || ' ' || u.lastname as Creator, ct.name "
                          + "from clubs c "
                          + "join users u on u.id_club = c.id "
                          + "join countries ct on c.id_country = ct.id "
                          + "where u.role = 'Coach';";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();  
            //List<Club> allClub = new List<Club>();
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        allClub.Add(new Club(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
            //    }
            //}
            DataTable dttable = new DataTable();
            dttable.Load(reader);
            reader.Close();
            return dttable;
        }

        public int getIdClubByName(string name)
        {
            string query = "select id from clubs where name = '" + name + "';";
            NpgsqlCommand command = new NpgsqlCommand(query, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            int res = -1;
            reader.Read();
            if (reader.HasRows)
            {
                res = reader.GetInt32(0);
            }
            reader.Close();
            return res;
        }
    }
}
