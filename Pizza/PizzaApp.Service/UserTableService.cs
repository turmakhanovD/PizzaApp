
using RegistrationSystem;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PizzaApp.Service
{
    public class UserTableService
    {
        private readonly string _connectionString;

        public UserTableService()
        {
            _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ТурмаханД\source\repos\PizzaApp\PizzaApp.Model\Database1.mdf;Integrated Security=True";
        }

        public List<User> SelectUsers()
        {
            var data = new List<User>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = "select * from Users";

                    var sqlDataReader = command.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        int id = (int)sqlDataReader["Id"];
                        string login = sqlDataReader["Login"].ToString();
                        string password = sqlDataReader["Password"].ToString();
                        string phonenumber = sqlDataReader["PhoneNumber"].ToString();

                        data.Add(new User
                        {
                            Id = id,
                            Login = login,
                            Password = password,
                            PhoneNumber = phonenumber
                        });
                    }
                    sqlDataReader.Close();

                }
                catch (SqlException exception)
                {
                    //обработать
                    throw;
                }
                catch (Exception exception)
                {
                    //обработать
                    throw;
                }
            }
            return data;
        }

        public void InsertUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = $"insert into Users (Login, Password, PhoneNumber) values ('{user.Login}','{user.Password}','{user.PhoneNumber}')";
                    int affectedRows = command.ExecuteNonQuery();

                    if (affectedRows < 1)
                    {
                        throw new Exception("Вставка не удалась");
                    }
                }
                catch (SqlException exception)
                {
                    //обработать
                    throw;
                }
                catch (Exception exception)
                {
                    //обработать
                    throw;
                }
            }
        }

        //public void DeleteUserById(int id)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    using (var command = connection.CreateCommand())
        //    {
        //        try
        //        {
        //            connection.Open();
        //            command.CommandText = $"delete from User where Id = {id}";
        //            int affectedRows = command.ExecuteNonQuery();

        //            if (affectedRows < 1)
        //            {
        //                throw new Exception("Вставка не удалась");
        //            }
        //        }
        //        catch (SqlException exception)
        //        {
        //            //обработать
        //            throw;
        //        }
        //        catch (Exception exception)
        //        {
        //            //обработать
        //            throw;
        //        }
        //    }
        //}
    }
}
