using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL.IRepositories
{
    public interface IStadiumRepository
    {
        DataTable readAllStadium();
        Stadium readbyName(string name);
        Stadium readbyId(int id);
        void create(Stadium stadium);
        void update(Stadium stadium);
        void delete(Stadium stadium);
        List<int> readAllId();
    }
}
