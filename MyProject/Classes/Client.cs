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


        private string Family{get; set;} 
    }
}