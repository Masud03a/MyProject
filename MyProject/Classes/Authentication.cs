using System;

namespace MyProject
{
    public class Authentication
    {
       
       private string username = string.Empty; 
       private string userpassword = string.Empty; 
       public Authentication(string _name, string _password)
       {
           username = _name;
           userpassword = _password;
       }

       public bool RegistrateAccount(string _table_name)
        {
            if(this.isPreviouslyCreated(true))
                return false;
            else
            {
                try
                {
                    SQLManager _sqlManager = new SQLManager();
                    _sqlManager.InsertData($"{_table_name}", "_name, _password", "'{username}', '{userpassword}'");
                    return true;
                }
                catch(Exception ex)
                {
                    Log.Error(ex.Message);
                    return false;
                } 
            }
        }
        public bool isPreviouslyCreated(bool _admin);
        {
            string _query = string.Empty;
            if(_admin) 
                _query =  $"select _name from admin_list_table where _name={username}";
    
            else
                _query = $"select _name from users_list_table where _name={username}";

            SQLManager _sqlManager = new SQLManager(); 
            SqlDataReader _reader = _sqlManager.Select(_query);
            if(_reader.FieldCount > 0)
                return true;
            else
                return false;   

        }
    }          
}
