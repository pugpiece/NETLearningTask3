using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.DAL;
using Users.Entities;

namespace Users.BLL
{
    public class UsersLogic : IUsersLogic
    {
        private IUsersDao UserDao;
        public UsersLogic()
        {
            UserDao = new UsersDaoBD();
        }

        public void AddAward(Award value)
        {
            UserDao.AddAward(value);
        }

        public void AddUser(User value)
        {
            UserDao.AddUser(value);
        }

        public IEnumerable<Award> GetAllAwards()
        {
            return UserDao.GetAllAwards();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return UserDao.GetAllUsers();
        }

        public void RemoveAward(int index)
        {
            UserDao.RemoveAward(index);
        }

        public void RemoveUser(int index)
        {
            UserDao.RemoveUser(index);
        }
    }
}
