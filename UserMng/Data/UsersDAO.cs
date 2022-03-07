using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UserMng.Models;

namespace UserMng.Data
{
    internal class UsersDAO
    {
        private string connectionString = @"Data Source=LAPTOP-3FJKDN09\SQLEXPRESS;Initial Catalog=UserManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //perfoms CRUD
        public List<Users> FetchAll()
            {
            List<Users> returnList = new List<Users>();

            //access Database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "EXECUTE FetchAllData";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
               

                if (reader.HasRows)
                {
                    while(reader.Read())

                    {
                        Users users = new Users();
                        users.id = reader.GetInt32(0);
                        users.name = reader.GetString(1);
                        users.description = reader.GetString(2);
                        users.email = reader.GetString(3);
                        users.password = reader.GetString(4);
                        users.confirm_password = reader.GetString(5);
                        users.groupID = reader.GetString(6);
                        users.isActive = reader.GetString(7);

                        returnList.Add(users);
                        
                    }                }

            }
                return returnList;
            }

        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))

            {


                string sqlQuery = "DELETE FROM dbo.t_users WHERE id = @Id";


                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 100).Value = id;
                connection.Open();

                int deletedID = command.ExecuteNonQuery();


                return deletedID;

            }
        }

        public int CreateOrUpdate(Users usersmd)
        {


            //access Database
            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                

                string sqlQuery = "";

                if (usersmd.id == 0)
                {
                    sqlQuery = "EXECUTE InsertData @Name,@Description,@Email,@Password,@cfPass,'10','N')";

                }
                else
                {
                    sqlQuery = "EXECUTE usp_Edit_data @Id,@Description,@Email,@groupID,@isActive";

                }


                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 100).Value = usersmd.id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 100).Value = usersmd.name;
                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 100).Value = usersmd.description;
                command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 100).Value = usersmd.email;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 100).Value = usersmd.password;
                command.Parameters.Add("@cfPass", System.Data.SqlDbType.VarChar, 100).Value = usersmd.confirm_password;
                command.Parameters.Add("@groupID", System.Data.SqlDbType.VarChar, 100).Value = usersmd.groupID;
                command.Parameters.Add("@isActive", System.Data.SqlDbType.VarChar, 100).Value = usersmd.isActive;
                connection.Open();

                int newID = command.ExecuteNonQuery();


                return newID;

            }


        }
    }
}