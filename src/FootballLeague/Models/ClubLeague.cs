using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class ClubLeague
    {
        private int idClub;
        private int idLeague;

        public int IdClub { get => idClub; set => idClub = value; }
        public int IdLeague { get => idLeague; set => idLeague = value; }

        public ClubLeague(int idClub, int idLeague)
        {
            this.idClub = idClub;
            this.idLeague = idLeague;
        }
    }
}
