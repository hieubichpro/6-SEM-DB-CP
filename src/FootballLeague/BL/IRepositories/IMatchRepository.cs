using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL.IRepositories
{
    public interface IMatchRepository
    {
        void create(Match match);
        void update(int id_match, int homeGoal, int guestGoal);
        List<Match> readByIdLeague(int id_league);
    }
}
