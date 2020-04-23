using System;
using System.Data.SqlClient;
using System.Data; 
using System.Globalization;
using System.Collections.Generic;

namespace MyProject
{
    public class Applications
    { 
        private int ApplicationID{get; set;}
        private List<int> ApplicationIDs = new List<int>();
        private int ID{get; set;}
        public string Approved{get; set;}
        private double Amount {get; set;}
        private int Term{get; set;}
        private string Goal{get; set;}
        private double Salary{get; set;}

        public Applications(int ID, double Amount, int Term, string Goal, double Salary){
            this.Amount = Amount;
            this.ID = ID;
            this.Term = Term;
            this.Goal = Goal;
            this.Salary = Salary;
        }

        public Applications(int ID){
            this.ID = ID; 
        }

        public bool RegisterForCredit() {
            bool isCreditRegistered = false;
            
            int clientId = ID;
            
            double salary = this.Salary;

            //! Getting info about Client by ID 
            SqlConnection connection = new SqlConnection(Connection.connectionString);

            if ( connection.State == ConnectionState.Open ) {
                connection.Close();
            }
            connection.Open();

            string commandText = $"Select * from Client where ID = {clientId}";
            SqlCommand command = new SqlCommand(commandText, connection);
            SqlDataReader reader = command.ExecuteReader(); 

            string Firstname = " ", Secondname=" ", Gender =" ", Citizenship = " ", Family = " ", CreditGoal = " ";
            int Age = 0, CreditTerm = 0;
            double Salary = 0.0, CreditAmount = 0.0; 

            CreditAmount = Amount;
            CreditTerm = Term;
            CreditGoal = Goal;
            while (reader.Read()) {
                Firstname = reader.GetValue(1).ToString().Trim();
                Secondname = reader.GetValue(2).ToString().Trim();
                Gender = reader.GetValue(4).ToString().Trim();
                Age = int.Parse(reader.GetValue(5).ToString().Trim()); 
                Citizenship = reader.GetValue(6).ToString().Trim(); 
                Family = reader.GetValue(7).ToString().Trim(); 
            }

            reader.Close();

            //! New Calculation 
            int amountHistoryClosed = History.checkForClientHistory(ID);
            int sum = 0;

            if (Gender == "Male") 
            {
                sum ++;
            } 
            else
            {
                sum += 2; 
            }  

            if ( amountHistoryClosed == 0 )
            {
                sum += -1;
            }
            else if ( amountHistoryClosed <= 2 )
            {  
                sum += 1;
            }
            else
            {
                sum += 2; 
            }    

            switch (Family)
            {  
                case "Single":{sum+=1;} break;
                case "Married":{sum+=2;}break;  
                case "Divorced":{sum+=1;}break;
                case "Widow":{sum+=2;}break;  
            }

            if (Age >= 26 && Age <= 35)
            {
                sum+=1;     
            }
            else if ( Age >= 36 && Age <= 62 )
            {
                sum+=2;
            }
            else if ( Age >= 63 )
            {
                sum+=1;       
            }

            if ( Citizenship == "Tajikistan" )
            {
                sum+=1;
            }

            double CreditPercent = ((CreditAmount * 100) / salary);
            System.Console.WriteLine(salary);

            int[] percentPerCredit = new int[]{10, 15, 20, 25};
            
            if ( CreditPercent <= 80 )
            {
                sum += 4;
            }
            else if ( CreditPercent > 80 && CreditPercent <= 150 )
            {
                sum += 3;
            }
            else if ( CreditPercent > 150 && CreditPercent <= 250 )
            {
                sum += 2;
            }
            else
            {
                sum += 1; 
            }     
            switch( CreditGoal )
            {
                case "Home":
                {
                    sum += 2;
                }break;
                case "Fix":
                {
                    sum += 1; 
                } break; 
                case "Others":
                {
                    sum -= 1; 
                }break;
                
                default: sum += 0; 
                break;           
            }

            //! percents 
            int percents; 
            if ( CreditTerm < 6 )
            {
                CreditAmount += ( CreditAmount * percentPerCredit[0] / 100 );
                percents = percentPerCredit[0];
            }
            else if (CreditTerm <= 8)
            {
                CreditAmount += ( CreditAmount * percentPerCredit[1] / 100 );
                percents = percentPerCredit[1];
            }
            else{
                CreditAmount += ( CreditAmount * percentPerCredit[2] / 100 ); 
                percents = percentPerCredit[2]; 
            }

            //! 12 Months
            sum+=1;

            if ( sum > 11 )
            {
                Approved = "YES";
            }
            else
            {
                Approved = "NO";    
            }

            //! Calculation end

            connection.Close();
            connection = new SqlConnection(Connection.connectionString);
            connection.Open();
            commandText = $"Insert into Applications([ClientID], [Firstname], [Secondname], [Amount], [Term], [Approved], [Goal], [Salary], [PercentCredit]) Values({ID}, '{Firstname}', '{Secondname}', {CreditAmount}, {CreditTerm}, '{Approved}', '{CreditGoal}', '{Math.Round(salary,3)}', {percents})";
            command = new SqlCommand(commandText, connection);
            var result = command.ExecuteNonQuery(); 

            getApplicationIDS();

            //! IF application was Approved, create graph of payment 
            if ( Approved == "YES" )
            {
                connection.Close();
                connection.Open();
                SqlConnection connection1 = new SqlConnection(Connection.connectionString);
                DateTime now = DateTime.Now.Date;
                now.AddMonths(1);
                string strnow;

                int lastID = ApplicationIDs[ApplicationIDs.Count-1];
                // History.AddApplicationToHistory(lastID, CreditAmount);
                lastID++;

                for ( int i = 0; i < CreditTerm; i++ )
                {
                    strnow = now.ToString().Substring(0,10);
                    string commandText1 = $"Insert into Payment([ID], [ClientID], [DatePayment], [AmountShouldPay], [Delays], [LastPayment]) Values({lastID}, {ID}, '{strnow}', '{Math.Round((CreditAmount/CreditTerm))}', 0, NULL)";
                    SqlCommand command1 = new SqlCommand(commandText1, connection); 
                    command1.ExecuteNonQuery(); 
                    now = now.AddMonths(1); 
                }
            }


            if ( result == 1 )isCreditRegistered = true;
            return isCreditRegistered; 
        }     


                












        
    }
}