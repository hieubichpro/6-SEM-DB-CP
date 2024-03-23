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
        private ClubRepository clubRepo;

        public ClubRepository ClubRepo { get => clubRepo; set => clubRepo = value; }

        public ClubService(ClubRepository clubRepo)
        {
            this.clubRepo = clubRepo;
        }
        public void insertClub(string name, int idUser, int idCountry)
        {
            clubRepo.insertClub(name, idUser, idCountry);
        }
        public DataTable getAllClubAndInfo()
        {
            return clubRepo.getAllClubAndInfo();
        }

        public int getIdClubByName(string name)
        {
            return clubRepo.getIdClubByName(name);
        }
    }
}
