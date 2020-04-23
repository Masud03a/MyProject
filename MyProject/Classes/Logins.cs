using System;
using System.Data.SqlClient;
using System.Data;  

namespace MyProject
{
    public class Logins
    {
        private string login{get; set;}
        private string password{get; set;}

        public bool loginState = false, registerState = false;
        public Logins(string login, string password){
            this.login = login;
            this.password = password; 
        }
        public Logins(){

        }

        public int Register(){ 
            SqlConnection connection = new SqlConnection(Connection.connectionString);
            
            if ( connection.State == ConnectionState.Open ){
                connection.Close();
            }
            connection.Open();

            if ( checkLogin() == false ){
                System.Console.WriteLine("Incorrect type of login(Use your phone numbers)");
                return -1; 
            }

            int t = getUserID(); 
            if ( t == -1 ){
                string insertCommand = $"Insert into Logins([Login], [Password]) Values ('{login}', '{password}')";
                
                SqlCommand command = new SqlCommand(insertCommand, connection);
                
                var result = command.ExecuteNonQuery(); 
                return result; 
            }

            else{
                System.Console.WriteLine("Sorry, you already have account.... on this numbers");
                return -2; 
            }

        }

        public int Login(){
            if ( checkLogin() == false ){
                System.Console.WriteLine("Error: Incorrect type of login");
                return -1; 
            }
            else
            {
                int ID = -1;
                ID = getUserID();
                if ( ID != -1 ){
                    System.Console.WriteLine("Success");
                    return ID; 
                }
                else
                {
                    System.Console.WriteLine("Error: user not found");
                    return -2; 
                }

            }

        }
        
             

}