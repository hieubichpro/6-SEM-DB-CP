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
    public class RequestService
    {
        private IRequestRepository requestRepo;

        public RequestService(IRequestRepository requestRepo)
        {
            this.requestRepo = requestRepo;
        }

        internal void insertRequestToClub(int id_club, int id_user)
        {
            Request request = new Request(DateTime.Now, -1, id_club, id_user);
            requestRepo.create(request);
        }

        internal DataTable getAllRequestToClub(int idClub)
        {
            return requestRepo.readbyIdClub(idClub);
        }

        internal void deleteRequestByIdUser(int idUser)
        {
            List<Request> requests = requestRepo.readbyIdUser(idUser);
            if (requests != null)
            {
                foreach (Request request in requests)
                {
                    requestRepo.delete(request);
                }
            }
            else
            {
                throw new Exception("Такой пользователь не имеет никаких заявок");
            }
        }

        internal void deleteRequestByIdRequest(int idRequest)
        {
            Request request = requestRepo.readbyId(idRequest);
            if (request != null)
            {
                requestRepo.delete(request);
            }
            else
            {
                throw new Exception("Не сущ такая заявка");
            }
        }

        internal void insertRequestToLeague(int id_league, int id_club, int id_user)
        {
            Request request = new Request(DateTime.Now, id_league, id_club, id_user);
            requestRepo.create(request);
        }

        internal DataTable getAllRequestOfFootballer(int idFootballer)
        {
            return requestRepo.readbyIdFootballer(idFootballer);
        }

        internal DataTable getAllRequestToLeague(int idLeague)
        {
            return requestRepo.readbyIdLeague(idLeague);
        }

        internal void deleteRequestByIdClub(int idClub)
        {
            List<Request> requests = requestRepo.readByIdClub(idClub);
            if (requests != null)
            {
                foreach (Request request in requests)
                {
                    requestRepo.delete(request);
                }
            }
            else
            {
                throw new Exception("Клуб не имеет заявок");
            }
        }
    }
}
