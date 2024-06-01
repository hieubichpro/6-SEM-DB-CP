using FootballLeague.BL.IRepositories;
using FootballLeague.DA;
using FootballLeague.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL
{
    public class LeagueService
    {
        private ILeagueRepository leagueRepo;
        private IMatchRepository matchRepo;
        private IClubRepository clubRepo;
        private IStadiumRepository stadiumRepo;
        public LeagueService(ILeagueRepository leagueRepo, IMatchRepository matchRepo, IClubRepository clubRepo, IStadiumRepository stadiumRepo)
        {
            this.leagueRepo = leagueRepo;
            this.matchRepo = matchRepo;
            this.clubRepo = clubRepo;
            this.stadiumRepo = stadiumRepo;
        }

        public void insertLeague(string name, double rating, int idUser, int idCountry)
        {
            League league = leagueRepo.readbyName(name);
            if (league == null)
            {
                league = new League(name, rating, idUser, idCountry);
                leagueRepo.create(league);
            }
            else
            {
                throw new Exception("не сущ");
            }
        }

        internal DataTable getAllLeagueInfo()
        {
            return leagueRepo.readAllLeagues();
        }

        internal void insertIntoTableLeagueClub(int idLeague, int idClub)
        {
            ClubLeague clubLeague = new ClubLeague(idClub, idLeague);
            leagueRepo.createOnCLTable(clubLeague);
        }

        internal DataTable getAllLeagueByIDUser(int idUser)
        {
            return leagueRepo.readbyIdUser(idUser);
        }

        public bool haveLeague(int idUser)
        {
            return leagueRepo.readByIdUser(idUser);
        }

        internal int createTimeTable(int id_league)
        {
            List<Match> matches = matchRepo.readByIdLeague(id_league);
            if (matches.Count > 0)
                return 3;
            List<int> clubs = clubRepo.readAllClubByIdLeague(id_league);
            if (clubs.Count == 0)
                return 1;
            else if (clubs.Count % 2 == 1)
                return 2;
            else
                leagueRepo.schedule(id_league);
            return 0;
        }

        internal void deleteLeague(int id_league)
        {
            leagueRepo.deleteById(id_league);
        }

        internal bool hasStarted(int id_league)
        {
            List<Match> matches = matchRepo.readByIdLeague(id_league);
            if (matches.Count == 0)
                return false;
            return true;
        }

        public DataTable getTableLeague(int id_league)
        {
            return leagueRepo.readTable(id_league);
        }
        //internal League getLastInsertedLeague()
        //{
        //    return leagueRepo.getLastInsertedLeague();\
        // ????
        //}
    }

    //public class ScheduleAlgorithm
    //{
    //    private int id_league;
    //    private IClubRepository clubRepo;
    //    private IMatchRepository matchRepo;
    //    private IStadiumRepository stadiumRepo;
    //    private List<int> full_id;
    //    public List<int> Full_id { get => full_id; set => full_id = value; }

    //    public ScheduleAlgorithm(int id_league, IClubRepository clubRepo, IMatchRepository matchRepo, IStadiumRepository stadiumRepo)
    //    {
    //        this.id_league = id_league;
    //        this.clubRepo = clubRepo;
    //        this.matchRepo = matchRepo;
    //        this.stadiumRepo = stadiumRepo;
    //        this.full_id = clubRepo.readAllClubByIdLeague(id_league);
    //    }
    //    public void rotate()
    //    {
    //        int size = full_id.Count;
    //        int last = full_id[size - 1];
    //        for (int i = size - 1; i >= 2; i--)
    //        {
    //            full_id[i] = full_id[i - 1];
    //        }
    //        full_id[1] = last;
    //    }
    //    public int create()
    //    {
    //        int size = full_id.Count;
    //        if (size == 0)
    //            return -1;
    //        if (size % 2 == 1)
    //            return -2;
    //        List<int> id_stadium = stadiumRepo.readAllId();
    //        var random = new Random();
    //        DateTime startFirstLeg = new DateTime(2024, 5, 24);
    //        DateTime startSecondLeg = startFirstLeg.AddDays(7 * (size - 1));
    //        for (int week = 0; week < (size - 1); week++)
    //        {
    //            matchRepo.create(new Match(id_league, full_id[0], full_id[1], id_stadium[random.Next(id_stadium.Count)], startFirstLeg.ToString("dd.MM.yy"), week + 1));
    //            matchRepo.create(new Match(id_league, full_id[1], full_id[0], id_stadium[random.Next(id_stadium.Count)], startSecondLeg.ToString("dd.MM.yy"), week + 1 + size - 1));
    //            for (int i = 0; i < size / 2 - 1; i++)
    //            {
    //                matchRepo.create(new Match(id_league, full_id[2 + i], full_id[size - 1 - i], id_stadium[random.Next(id_stadium.Count)], startFirstLeg.ToString("dd.MM.yy"), week + 1));
    //                matchRepo.create(new Match(id_league, full_id[size - 1 - i], full_id[2 + i], id_stadium[random.Next(id_stadium.Count)], startSecondLeg.ToString("dd.MM.yy"), week + 1 + size - 1));
    //            }
    //            rotate();
    //            startFirstLeg = startFirstLeg.AddDays(7);
    //            startSecondLeg = startSecondLeg.AddDays(7);
    //        }
    //        return 0;
    //    }



    //}
}
