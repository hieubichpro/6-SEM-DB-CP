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
    public class CountryService
    {
        private ICountryRepository countryRepo;
        public CountryService(ICountryRepository countryRepo)
        {
            this.countryRepo = countryRepo;
        }

        public List<Country> getAllCountries()
        {
            return countryRepo.readAllCountries();
        }

        internal Country getCountryByName(string name)
        {
            return countryRepo.readbyName(name);
        }
    }
}

