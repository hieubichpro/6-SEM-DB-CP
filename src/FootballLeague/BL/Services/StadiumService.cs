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
    public class StadiumService
    {
        private IStadiumRepository stadiumRepo;
        private ICountryRepository countryRepo;

        public StadiumService(IStadiumRepository stadiumRepo, ICountryRepository countryRepo)
        {
            this.stadiumRepo = stadiumRepo;
            this.countryRepo = countryRepo;
        }

        public DataTable read()
        {
            return stadiumRepo.readAllStadium();
        }

        internal void insertStadium(string name, string capacity, int idCountry)
        {
            Stadium stadium = stadiumRepo.readbyName(name);
            if (stadium == null)
            {
                stadium = new Stadium(name, Int32.Parse(capacity), idCountry);
                stadiumRepo.create(stadium);
            }
            else
            {
                throw new Exception("Уже существует");
            }
        }

        internal void deleteStadiumById(int id)
        {
            Stadium stadium = stadiumRepo.readbyId(id);
            if (stadium != null)
            {
                stadiumRepo.delete(stadium);
            }
            else
            {
                throw new Exception("Нет такого");
            }
        }

        public DataTable getAllStadiumAndInfo()
        {
            return stadiumRepo.readAllStadium();
        }

        public void modifyStadium(int id, string name, string capacity, string country)
        {
            Stadium stadium = stadiumRepo.readbyId(id);
            stadium.Name = name;
            stadium.Capacity = Int32.Parse(capacity);
            stadium.IdCountry = countryRepo.readbyName(country).Id;
            stadiumRepo.update(stadium);
        }
    }
}
