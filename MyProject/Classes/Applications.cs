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
            


        
    }
}