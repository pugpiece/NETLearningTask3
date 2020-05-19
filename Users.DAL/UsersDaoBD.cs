using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;
using System.Data.SqlClient;

namespace Users.DAL
{
    public class UsersDaoBD : IUsersDao
    {
        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=UsersAndAwards;Integrated Security=True";

        public IEnumerable<User> GetAllUsers()
        {
            var result = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open(); //открываем соединение
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    int tempID = result.FindIndex(x => x.Id == (int)read["ID"]);
                    if (tempID == -1)
                    {
                        int Id = (int)read["ID"];
                        string UserName = (string)read["USERNAME"];
                        DateTime DateOfBirth = (DateTime)read["DATE_OF_BIRTH"];
                        int Age = (int)read["AGE"];

                        User user = new User(Id, UserName, DateOfBirth, Age);
                        
                        string award = (string)read["TITLE"];
                        if (award != "no")
                            user.Awards.Add(award);

                        result.Add(user);
                    }
                    else
                    {
                        string award = (string)read["TITLE"];
                        if (award != "no")
                            result[tempID].Awards.Add(award);
                    }
                }


            }
            return result;
        }

        public void AddUser(User value)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddUser";

                var parameteUsername = command.CreateParameter();
                parameteUsername.DbType = System.Data.DbType.String;
                parameteUsername.Value = value.UserName;
                parameteUsername.ParameterName = "@Username";
                command.Parameters.Add(parameteUsername);

                var parameterDateOfBirth = command.CreateParameter();
                parameterDateOfBirth.DbType = System.Data.DbType.DateTime;
                parameterDateOfBirth.Value = value.DateOfBirth;
                parameterDateOfBirth.ParameterName = "@DateOfBirth";
                command.Parameters.Add(parameterDateOfBirth);

                var parameterAge = command.CreateParameter();
                parameterAge.DbType = System.Data.DbType.Int32;
                parameterAge.Value = value.Age;
                parameterAge.ParameterName = "@Age";
                command.Parameters.Add(parameterAge);

                connection.Open();

                command.ExecuteScalar();
            }
        }

        public void RemoveUser(int index)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveUser", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@index", index);
                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(SqlException e)
                {
                    Console.WriteLine("Удалить пользователя нельзя, так как у него есть некоторые награды");
                }
            }
        }


        public IEnumerable<Award> GetAllAwards()
        {
            var result = new List<Award>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetAllAwards", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open(); //открываем соединение
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var award = new Award
                    {
                        Id = (int)read["ID"],
                        Title = (string)read["TITLE"]
                    };
                    result.Add(award);
                }


            }
            return result;
        }


        public void AddAward(Award value)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddAward";

                var parameteTitle = command.CreateParameter();
                parameteTitle.DbType = System.Data.DbType.String;
                parameteTitle.Value = value.Title;
                parameteTitle.ParameterName = "@Title";
                command.Parameters.Add(parameteTitle);

                connection.Open();

                command.ExecuteScalar();
            }
        }


        public void RemoveAward(int index)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveAward", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@index", index);
                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Удалить награду нельзя, так как она есть у некоторых пользователей");
                }
            }
        }

    }
}
