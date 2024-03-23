using System;
namespace Models
{
    public class Request
    {
        private int id;
        private DateTime time;
        private int idLeague;
        private int idClub;
        private int idUser;

        public Request(int id, DateTime time, int idLeague, int idClub, int idUser)
        {
            this.id = id;
            this.time = time;
            this.idLeague = idLeague;
            this.idClub = idClub;
            this.idUser = idUser;
        }

        public int Id { get => id; set => id = value; }
        public DateTime Time { get => time; set => time = value; }
        public int IdLeague { get => idLeague; set => idLeague = value; }
        public int IdClub { get => idClub; set => idClub = value; }
        public int IdUser { get => idUser; set => idUser = value; }
    }
}