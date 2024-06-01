using FootballLeague.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL.IRepositories
{
    public interface ILeagueRepository
    {
        League readbyName(string name);
        void create(League league);
        DataTable readAllLeagues();
        DataTable readbyIdUser(int idUser);
        DataTable readTable(int id_league);
        void createOnCLTable(ClubLeague clubLeague);

        bool readByIdUser(int idUSer);
        void schedule(int id_league);

        void deleteById(int id_league);
    }
}
