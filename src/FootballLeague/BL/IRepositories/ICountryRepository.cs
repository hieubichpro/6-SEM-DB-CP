using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL.IRepositories
{
    public interface ICountryRepository
    {
        List<Country> readAllCountries();
        Country readbyName(string name);
    }
}
