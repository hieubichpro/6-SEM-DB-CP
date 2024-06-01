using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace FootballLeague.BL.IRepositories
{
    public interface IUserRepository
    {
        User readById(int id);
        User readByLogin(string login);
        List<User> readByRole(string role);
        DataTable readAllFootballer(int idClub);
        DataTable readAllUserByRole(string role);
        DataTable readAllUser();
        void create(User user);
        void update(User user);
        void delete(int id);
    }
}
