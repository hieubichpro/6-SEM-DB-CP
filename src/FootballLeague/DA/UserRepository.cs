using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.DA
{
    class UserRepository
    {
        private static UserRepository instance;
        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserRepository();
                return instance;
            }
            private set { instance = value; }
        }

        private UserRepository() { }

        public bool Login(string username, string password)
        {
            string query = "select * from users where login = '" + username + "' and password = '" + password + "'";
            DataTable res = Connecter.Instance.ExecuteQuery(query);
            return res.Rows.Count > 0;
        }

        public void Register(string username, string password, string role, string firstname, string lastname, int age)
        {

        }

    }
}
