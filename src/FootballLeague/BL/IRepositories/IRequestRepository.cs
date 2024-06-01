using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL.IRepositories
{
    public interface IRequestRepository
    {

        void create(Request request);
        void delete(Request request);
        void update(Request request);
        Request readbyId(int id);
        List<Request> readbyIdUser(int idUser);
        List<Request> readByIdClub(int idClub);
        DataTable readbyIdFootballer(int idFootballer);
        DataTable readbyIdClub(int idClub);
        DataTable readbyIdLeague(int idLeague);
    }
}
