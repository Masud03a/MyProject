using System;
using System.Data;
using System.Data.SqlClient;

namespace MyProject
{
    class SQLManager : InterSqlCode
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

        public bool isConnected(SqlConnection _sqlConn)
        {
            if(_sqlConn.State == ConnectionState.Open)
                return true;
            else
                return false;
        }

        public SqlDataReader Select(string _query)
        {
            try
            {
                SqlConnection _sqlConn = new SqlConnection(this.ConnectionString());
                _sqlConn.Open();
                if(this.isConnected(_sqlConn))
                {
                    SqlCommand _sqlCmd = new SqlCommand(_query, _sqlConn);
                    var reader = _sqlCmd.ExecuteReader();
                    _sqlConn.Close();
                    return reader;
                }
                else
                    return null;
            }

            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }    
    }
}            