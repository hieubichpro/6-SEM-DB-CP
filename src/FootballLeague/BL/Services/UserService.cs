using FootballLeague.BL.IRepositories;
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
        private IUserRepository userRepo;
        public UserService(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public User Login(string login, string password)
        {
            User user = userRepo.readByLogin(login);
            //if (user == null)
            //    throw new Exception("Не существует такого пользователя");
            //else
            //{
            //    if (!user.checkPassword(password))
            //        throw new Exception("Неверный пароль");
            //}
            //return user;
            if (user == null || !user.checkPassword(password))
                user = null;
            return user;
        }

        public int Register(string login, string password, string role, int age, string firstname = "", string lastname = "")
        {
            User user = userRepo.readByLogin(login);
            if (user != null)
            {
                return 1;
            }
            else
            {
                user = new User(login, password, role, firstname, lastname, age);
                userRepo.create(user);
                return 0;
            }
        }

        public void ChangePassword(User user, string password)
        {
            user.Password = password;
            userRepo.update(user);
        }

        internal void deleteUser(int id_user)
        {
            userRepo.delete(id_user);
        }

        internal void ChangeInfoUser(User user, string firstname, string lastname, int age)
        {
            user.FirstName = firstname;
            user.LastName = lastname;
            user.Age = age;
            userRepo.update(user);
        }

        internal void updateIdClubOfUser(int idUser, int idClub)
        {
            User user = userRepo.readById(idUser);
            user.IdClub = idClub;
            userRepo.update(user);
        }

        internal void ChangeLogin(User user, string login)
        {
            user.Login = login;
            userRepo.update(user);
        }

        public List<User> getUserByRole(string role)
        {
            return userRepo.readByRole(role);
        }
        public DataTable getAllUserAndInfoByRole(string role)
        {
            return userRepo.readAllUserByRole(role);
        }
        internal DataTable getAllFootballerInClub(int idClub)
        {
            return userRepo.readAllFootballer(idClub);
        }

        public User getUserById(int id)
        {
            return userRepo.readById(id);
        }

        public DataTable readAllUsers()
        {
            return userRepo.readAllUser();
        }
    }
}
