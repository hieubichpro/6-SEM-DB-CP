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
        private CountryRepository countryRepo;
        public CountryService(CountryRepository countryRepo)
        {
            this.countryRepo = countryRepo;
        }

        public List<Country> getAllCountries()
        {
            return countryRepo.getAllCountries();
        }

        internal Country getCountryByName(string name)
        {
            return countryRepo.getCountryByName(name);
        }
    }
}

