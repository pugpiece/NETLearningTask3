using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruskov.Users
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите одно из следующих действий:" + Environment.NewLine + "1 - Добавить пользователя" + Environment.NewLine + "2 - Просмотреть перечень пользователей"
                    + Environment.NewLine + "3 - Удалить пользователя" + Environment.NewLine + "4 - Добавить награду" + Environment.NewLine + "5 - Просмотреть перечень наград"
                    + Environment.NewLine + "6 - Удалить награду" + Environment.NewLine);
                var action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        {
                            ConsoleLogic.AddUser();
                        }
                        break;
                    case "2":
                        {
                            ConsoleLogic.GetAllUsers();
                        }
                        break;
                    case "3":
                        {
                            ConsoleLogic.RemoveUser();
                        }
                        break;
                    case "4":
                        {
                            ConsoleLogic.AddAward();
                        }
                        break;
                    case "5":
                        {
                            ConsoleLogic.GetAllAwards();
                        }
                        break;
                    case "6":
                        {
                            ConsoleLogic.RemoveAward();
                        }
                        break;
                    default:
                        Console.WriteLine("Действие не указано!");
                        break;

                }
            }
        }
    }
}
