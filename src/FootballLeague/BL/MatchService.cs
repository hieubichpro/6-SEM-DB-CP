using FootballLeague.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL
{
    public class MatchService
    {
        private MatchRepository matchRepo;

        public MatchService(MatchRepository matchRepo)
        {
            this.matchRepo = matchRepo;
        }

        public MatchRepository MatchRepo { get => matchRepo; set => matchRepo = value; }
    }
}
