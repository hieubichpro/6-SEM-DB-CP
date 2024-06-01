using FootballLeague.BL.IRepositories;
using FootballLeague.DA;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL
{
    public class MatchService
    {
        private IMatchRepository matchRepo;
        private IClubRepository clubRepo;
        private IStadiumRepository stadiumRepo;

        public MatchService(IMatchRepository matchRepo, IClubRepository clubRepo, IStadiumRepository stadiumRepo)
        {
            this.matchRepo = matchRepo;
            this.clubRepo = clubRepo;
            this.stadiumRepo = stadiumRepo;
        }

        public string getNameClubById(int id)
        {
            return clubRepo.readbyId(id).Name;
        }
        public string getStadiumById(int id)
        {
            return stadiumRepo.readbyId(id).Name;
        }
        public List<Match> getMatchByIdLeague(int id_league)
        {
            return matchRepo.readByIdLeague(id_league);
        }

        public void setScoreMatch(int id_match, int homeGoal, int guestGoal)
        {
            matchRepo.update(id_match, homeGoal, guestGoal);
        }
    }
}
