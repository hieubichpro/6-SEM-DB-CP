using FootballLeague.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL
{
    public class StadiumService
    {
        private StadiumRepository stadiumRepo;

        public StadiumService(StadiumRepository stadiumRepo)
        {
            this.stadiumRepo = stadiumRepo;
        }

        public StadiumRepository StadiumRepo { get => stadiumRepo; set => stadiumRepo = value; }

        public DataTable getAllStadiumInfo()
        {
            return stadiumRepo.getAllStadiumInfo();
        }

        internal void insertStadium(string name, string capacity, int idCountry)
        {
            stadiumRepo.insertStadium(name, capacity, idCountry);
        }

        internal void deleteStadiumById(int id)
        {
            stadiumRepo.deleteStadiumById(id);
        }
    }
}
