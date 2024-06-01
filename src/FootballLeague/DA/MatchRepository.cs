using FootballLeague.BL.IRepositories;
using Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.DA
{
    public class MatchRepository : IMatchRepository
    {
        public void create(Match match)
        {
            string query = "insert into matches(id_league, id_home_club, id_guess_club, id_stadium, week, timestart) values (" + match.IdLeague + ", " + match.IdHomeTeam + ", " + match.IdGuestTeam + ", " + match.IdStadium + ", " + match.Week + ", '" + match.TimeStart + "');";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void update(int id_match, int homeGoal, int guestGoal)
        {
            string query = "update matches set goal_home_club = " + homeGoal + ", goal_guess_club = " + guestGoal + " where id = " + id_match + ";";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public List<Match> readByIdLeague(int id_league)
        {
            string query = "select * from matches where id_league = " + id_league + " order by week";
            NpgsqlDataReader reader = DataProvider.Instance.ExecuteQuery(query);
            List<Match> matches = new List<Match>();
            while (reader.Read())
            {
                int homeGoal = -1;
                int guestGoal = -1;
                if (!reader.IsDBNull(1))
                    homeGoal = reader.GetInt32(1);
                if (!reader.IsDBNull(2))
                    guestGoal = reader.GetInt32(2);
                matches.Add(new Match(reader.GetInt32(3), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(4), reader.GetString(8), reader.GetInt32(7), homeGoal, guestGoal, reader.GetInt32(0)));

            }
            reader.Close();
            return matches;
        }
    }
}
