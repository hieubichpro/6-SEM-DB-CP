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
    public class FeedbackRepository : IFeedbackRepository
    {
        public void create(Feedback feedback)
        {
            string query = "insert into feedbacks(grade, id_user, id_league) values"
                          + " (" + feedback.Grade + ", " + feedback.IdUser + ", " + feedback.IdLeague + ");";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
