using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.BLL;
using Users.Entities;

namespace Bruskov.Users
{
    class ConsoleLogic
    {
        private static IUsersLogic usersLogic = new UsersLogic();

        internal static void AddUser()
        {
            Console.WriteLine("Введите имя пользователя:");
            string Username = Console.ReadLine();

            Console.WriteLine("Введите дату рождения пользователя (в формате ДД-ММ-ГГГГ)");
            DateTime DateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Введите возраст пользователя");
            int Age = Convert.ToInt32(Console.ReadLine());

            User user = new User(Username, DateOfBirth, Age);

            usersLogic.AddUser(user);
        }

        internal static void GetAllUsers()
        {
            Console.WriteLine("Список пользователей:");
            var result = usersLogic.GetAllUsers();
            if (result.Any())
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.Id + " " + item.UserName + " " + item.DateOfBirth + " " + item.Age);
                    Console.WriteLine("Список наград:");
                    foreach (string award in item.Awards)
                    {
                        Console.WriteLine(award);
                    }
                }
            }
            else
            {
                Console.WriteLine("Пользователи отсутствуют!");
            }
        }

        internal static void RemoveUser()
        {
            Console.WriteLine("Введите индекс пользователя:");
            int index = Convert.ToInt32(Console.ReadLine());

            if (index < 0 && index >= usersLogic.GetAllUsers().Count())
            {
                Console.WriteLine("Неправильно указан индекс!");

            }
            else
            {
                if (!usersLogic.GetAllUsers().Any())
                {
                    Console.WriteLine("Список пользователей пуст!");
                }
                else
                {

                    usersLogic.RemoveUser(index);
                }

            }
        }

        internal static void AddAward()
        {
            Console.WriteLine("Введите название награды:");
            string Title = Console.ReadLine();

            Award award = new Award(Title);

            usersLogic.AddAward(award);
        }

        internal static void GetAllAwards()
        {
            Console.WriteLine("Список наград:");
            var result = usersLogic.GetAllAwards();
            if (result.Any())
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.Id + " " + item.Title);
                }
            }
            else
            {
                Console.WriteLine("Награды отсутствуют!");
            }
        }

        internal static void RemoveAward()
        {
            Console.WriteLine("Введите индекс награды:");
            int index = Convert.ToInt32(Console.ReadLine());

            if (index < 0 && index >= usersLogic.GetAllAwards().Count())
            {
                Console.WriteLine("Неправильно указан индекс!");

            }
            else
            {
                if (!usersLogic.GetAllAwards().Any())
                {
                    Console.WriteLine("Список наград пуст!");
                }
                else
                {

                    usersLogic.RemoveAward(index);
                }

            }
        }
    }
}
