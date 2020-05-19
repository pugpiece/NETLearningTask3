using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public List<string> Awards { get; set; }

        public User(){}

        public User(string newUserName, DateTime newDateOfBirth, int newAge)
        {
            UserName = newUserName;
            DateOfBirth = newDateOfBirth;
            Age = newAge;
            Awards = new List<string>();
        }

        public User(int newID, string newUserName, DateTime newDateOfBirth, int newAge)
        {
            Id = newID;
            UserName = newUserName;
            DateOfBirth = newDateOfBirth;
            Age = newAge;
            Awards = new List<string>();
        }
    }
}
