using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserMng.Models;

namespace UserMng.Data
{
    internal class UserDetails
    {
        private string connectionString = @"Data Source=LAPTOP-3FJKDN09\SQLEXPRESS;Initial Catalog=UserManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //perfoms CRUD

        public Users FetchOne(int id)
        {

            //access Database
            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                string sqlQuery = "SELECT * FROM dbo.t_users WHERE id = @id";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                Users users = new Users();

                if (reader.HasRows)
                {
                    while (reader.Read())

                    {
                        
                        users.id = reader.GetInt32(0);
                        users.name = reader.GetString(1);
                        users.description = reader.GetString(2);
                        users.email = reader.GetString(3);
                        users.password = reader.GetString(4);
                        users.confirm_password = reader.GetString(5);
                        users.groupID = reader.GetInt32(6).ToString();
                        users.isActive = reader.GetString(7);



                    }
                }
                return users;

            }
            

        }

        
    }
}