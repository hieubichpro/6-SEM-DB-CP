using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.DA
{
    public class MatchRepository
    {
        private NpgsqlConnection connector;

        public NpgsqlConnection Connector { get => connector; set => connector = value; }
        public MatchRepository(ConnectionArguments args)
        {
            this.connector = new NpgsqlConnection(args.getStringConnection());
            this.connector.Open();
        }
    }
}
