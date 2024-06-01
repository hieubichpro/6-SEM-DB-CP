using FootballLeague.BL.IRepositories;
using FootballLeague.DA;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL
{
    public class ClubService
    {
        private IClubRepository clubRepo;

        public ClubService(IClubRepository clubRepo)
        {
            this.clubRepo = clubRepo;
        }
        public void insertClub(string name, int idCountry)
        {
            Club club = clubRepo.readbyName(name);
            if (club == null)
            {
                club = new Club(name, idCountry);
                clubRepo.create(club);
            }
            else
            {
                throw new Exception("Уже сущ");
            }
        }
        public DataTable getAllClubAndInfo()
        {
            return clubRepo.readAllClubs();
        }
        public DataTable getAllMyClub(int idUser, string role)
        {
            return clubRepo.readbyIdUserAndRole(idUser, role);
        }

        public int getIdClubByName(string name)
        {
            Club club = clubRepo.readbyName(name);
            return club.Id;
        }

        public string getNameClubById(int id)
        {
            Club club = clubRepo.readbyId(id);
            return club.Name;
        }
    }
}
