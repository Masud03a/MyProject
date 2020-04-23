using System;
using System.Data.SqlClient;
using System.Data;

namespace MyProject 
{
    public class Client
    {
        private int ID {get; set;}
        private string Firstname{get; set;}
        private string Secondname{get; set;}
        private string Middlename{get; set;}
        private string Gender{get; set;}
        private int Age{get; set;}
        private string Citizenship {get; set;}
        private string Family{get; set;} 

        public Client(int ID) {
            this.ID = ID; 
        }

        public Client()
        {
        }

        public Client(string Firstname, string Secondname, string Middlename, string Gender, int Age, string Citizenship, string Family)
        {
            this.Firstname = Firstname;
            this.Secondname = Secondname;
            this.Middlename = Middlename;
            this.Gender = Gender;
            this.Age = Age; 
            this.Citizenship = Citizenship;
            this.Family = Family;
        }

        public void showAllClients() {
            SqlConnection connection = new SqlConnection(Connection.connectionString);
            if ( connection.State == ConnectionState.Open ){
                connection.Close();
            }
            connection.Open();

            string commandText = $"Select ID, Firstname, Secondname from Client";
            
            SqlCommand command = new SqlCommand(commandText, connection);

            SqlDataReader reader = command.ExecuteReader();

            System.Console.WriteLine("ID\t\tFirstname\t\tSecondname");

            while ( reader.Read() ) {
                string tempId = reader.GetValue(0).ToString();
                string tempFirstname = reader.GetValue(1).ToString().Trim();
                string tempSecondname = reader.GetValue(2).ToString().Trim();
                Console.Write(tempId + "\t\t" + tempFirstname);
                for ( int i = 0; i < 9 - tempFirstname.Length; i++ ) {
                    System.Console.Write(" ");
                } 
                Console.WriteLine("\t\t" + tempSecondname);
            }
            reader.Close(); 
        }
         public void showByClientId( int id ) {
            SqlConnection connection = new SqlConnection(Connection.connectionString);
            if ( connection.State == ConnectionState.Open ) {
                connection.Close();
            }
            connection.Open();

            string commandText = $"Select Firstname, Secondname from Client where ID = {id}"; 
            
            SqlCommand command = new SqlCommand(commandText, connection);

            SqlDataReader reader = command.ExecuteReader();
            
            adminFunctions: 
                System.Console.WriteLine("What you want to see:");
                System.Console.WriteLine("1. Applications");
                System.Console.Write("2. Payment graph of Application By ID\n3. Exit\nPlease type reference number: ");
            int adminChoice = int.Parse(Console.ReadLine());
    }
}