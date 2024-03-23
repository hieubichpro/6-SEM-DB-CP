using FootballLeague.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL
{
    public class LeagueService
    {
        private LeagueRepository leagueRepo;

        public LeagueRepository LeagueRepo { get => leagueRepo; set => leagueRepo = value; }
        public LeagueService(LeagueRepository leagueRepo)
        {
            this.leagueRepo = leagueRepo;
        }

        public void insertLeague(string name, string rating, int idUser, int idCountry)
        {
            leagueRepo.insertLeague(name, rating, idUser, idCountry);
        }
    }
}
