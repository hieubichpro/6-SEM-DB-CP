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
    public class UserService
    {
        private UserRepository userRepo;

        internal UserRepository UserRepo { get => userRepo; set => userRepo = value; }
        public UserService(UserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        public bool Login(string username, string password)
        {
            return userRepo.Login(username, password);
        }

        public void Register(string username, string password, string role, string firstname = "", string lastname = "", string age = "")
        {
            userRepo.Register(username, password, role, firstname, lastname, age);
        }

        public void ChangePassword(string username, string password)
        {
            userRepo.ChangePassword(username, password);
        }

        internal User getUserByUsername(string username)
        {
            return userRepo.getUserByUsername(username);
        }

        internal void ChangeInfoUser(string username, string firstname, string lastname, string age)
        {
            userRepo.ChangeInfoUser(username, firstname, lastname, age);
        }

        internal void updateIdClubOfUser(int idUser, int idClub)
        {
            userRepo.updateIdClubOfUser(idUser, idClub);
        }

        public List<User> getUserByRole(string role)
        {
            return userRepo.getUserByRole(role);
        }

        public DataTable getAllUserAndInfoByRole(string role)
        {
            return userRepo.getAllUserAndInfoByRole(role);
        }
    }
}
