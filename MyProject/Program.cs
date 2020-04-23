using System;
using System.Data.SqlClient;
using System.Data; 
using System.Collections.Generic; 

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string adminLogin = "admin";
            string adminPassword = "password";
            string[] familyArray = new string[]{"Single", "Married", "Divorced", "Widowed"}; 
            int clientID = 0; 

            //Dictionary
            var dictionary = new Dictionary<string, int>();
            
            int choice; 
            
            
            startCode:
                System.Console.Write(@"Welcome to AlifCreditHistory
                Are you client or admin?
                1. Admin
                2. User
                Please type reference number: ");
                
                int userInput; 
                if ( int.TryParse(Console.ReadLine(), out userInput) ){
                    if ( userInput == 1 ){
                        goto userLogin;
                         }
                    else if ( userInput == 2 ){
                        goto adminLogin; 
                    }
                    else{
                        goto startCode; 
                    }
                } 

            userLogin:
                System.Console.WriteLine("\t\t\t\tUser Panel");
                System.Console.Write(@"
                1. Register
                2. Login
                Please type referece number: ");
                int clientInput;
                if ( int.TryParse(Console.ReadLine(), out clientInput)){
                    if ( clientInput == 1 ){
                        goto userRegister;
                    }
                    else if ( clientInput == 2 ){   
                        goto clientLogin;
                    }
                    else{
                        System.Console.WriteLine("\t\t\t\tIncorrect choice. Try Again");
                        goto userLogin; 
                    }
                }
               
            clientLogin:
                System.Console.WriteLine("\t\t\t\tPlease type your login and password");
                System.Console.Write("\t\t\t\tLogin: ");
                string tempClientLogin = Console.ReadLine();
                System.Console.Write("\t\t\t\tPassword: ");
                string tempClientPassword = Console.ReadLine();
                Logins clientLogin = new Logins(tempClientLogin, tempClientPassword);
                   
                clientID = clientLogin.Login();
                
                if ( clientID == -1 || clientID == -2 ){
                    goto clientLogin;
                }
                else
                {
                    System.Console.WriteLine(clientID);
                    goto clientFunctions;
                }   

                                 
        }
    }
}
