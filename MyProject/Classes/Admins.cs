using System;
using System.Data;
using System.Data.SqlClient;

namespace AlifCreditProject
{
    public class Admins
    {
        public string login{get; set;}
        public string password{get; set;}
        public Admins(string login, string password){
            this.login = login;
            this.password = password;
        }

        public bool Register()
        {
            bool isRegistered = false; 
            SqlConnection connection = new SqlConnection(Connection.connectionString);
            if ( connection.State == ConnectionState.Open ) {
                connection.Close();
            } 
            connection.Open();
            if ( checkLogin() == false ){
                isRegistered = false;  
            }

            int t = getAdminID(); 
            if ( t == -1 ) {
                string insertCommand = $"Insert into Admins([Login], [Password]) Values ('{login}', '{password}')";
                SqlCommand command = new SqlCommand(insertCommand, connection);
                var result = command.ExecuteNonQuery();
                isRegistered = true;
            }

            else
            {
                System.Console.WriteLine("Sorry, you already have account....");
                isRegistered = false
            }    
            
            return isRegistered; 
        }
        


        }    