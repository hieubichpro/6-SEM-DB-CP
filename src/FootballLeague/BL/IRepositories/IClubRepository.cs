using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL.IRepositories
{
    public interface IClubRepository
    {
        Club readbyName(string name);
        Club readbyId(int id);
        void create(Club club);
        DataTable readAllClubs();
        DataTable readbyIdUserAndRole(int idUser, string role);

        List<int> readAllClubByIdLeague(int id_league);
    }
}
