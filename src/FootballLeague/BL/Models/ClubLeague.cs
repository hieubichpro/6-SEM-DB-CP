using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class ClubLeague
    {
        private int id;
        private int idClub;
        private int idLeague;

        public int IdClub { get => idClub; set => idClub = value; }
        public int IdLeague { get => idLeague; set => idLeague = value; }

        public ClubLeague(int idClub, int idLeague, int id = 1)
        {
            this.id = id;
            this.idClub = idClub;
            this.idLeague = idLeague;
        }
    }
}
