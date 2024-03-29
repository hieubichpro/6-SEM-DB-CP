using FootballLeague.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL
{
    public class RequestService
    {
        private RequestRepository requestRepo;

        public RequestRepository RequestRepo { get => requestRepo; set => requestRepo = value; }
        public RequestService(RequestRepository requestRepo)
        {
            this.requestRepo = requestRepo;
        }

        internal void insertRequestToClub(int id_club, int id_user)
        {
            requestRepo.insertRequestToClub(id_club, id_user);
        }

        internal DataTable getAllRequestToClub(int idClub)
        {
            return requestRepo.getAllRequestToClub(idClub);
        }

        internal void deleteRequestByIdUser(int idUser)
        {
            requestRepo.deleteRequestByIdUser(idUser);
        }

        internal void deleteRequestByIdRequest(int idRequest)
        {
            requestRepo.deleteRequestByIdRequest(idRequest);
        }

        internal void insertRequestToLeague(int id_league, int id_club, int id_user)
        {
            requestRepo.insertRequestToLeague(id_league, id_club, id_user);
        }

        internal DataTable getAllRequestOfFootballer(int idFootballer)
        {
            return requestRepo.getAllRequestOfFootballer(idFootballer);
        }

        internal DataTable getAllRequestToLeague(int idLeague)
        {
            return requestRepo.getAllRequestToLeague(idLeague);
        }
    }
}
