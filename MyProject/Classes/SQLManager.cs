using System;
using System.Data;
using System.Data.SqlClient;

namespace Bank_Credit_Manager
{
    class SQLManager : ISQLManager
    {
        public string ConnectionString()
        {
            return "Data Source=localhost;Initial catalog=Faridun;Integrated Security=True";
        }

        public void InsertData(string _tableName, string _columns, string _values)
        {
            try
            {
                SqlConnection _sqlConn = new SqlConnection(this.ConnectionString());
                _sqlConn.Open();
                if(this.isConnected(_sqlConn))
                {
                    SqlCommand _sqlCmd = new SqlCommand($"insert into dbo.{_tableName} ({_columns}) values({_values})", _sqlConn);
                    _sqlCmd.ExecuteNonQuery();
                    _sqlConn.Close();
                }

            catch(Exception ex)
            {
                Log.Error(ex.Message);
            }
        }         
    }
}            