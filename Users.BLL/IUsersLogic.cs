using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;

namespace Users.BLL
{
    public interface IUsersLogic
    {
        IEnumerable<User> GetAllUsers(); //просмотреть перечень пользователей
        void AddUser(User value); //добавить пользователя
        void RemoveUser(int index); //удалить пользователя по индексу
        IEnumerable<Award> GetAllAwards(); //просмотреть перечень наград
        void AddAward(Award value); //добавить награду
        void RemoveAward(int index); //удалить награду по индексу
    }
}
