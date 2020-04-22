using System.Data.SqlClient;

namespace MyProject
{
    public interface ISQLManager
    {
        string ConnectionString();
        void InsertData(string _tableName, string _columns, string _values);
        SqlDataReader Select(string _query);
        bool isConnected(SqlConnection _sqlConn);
    }
}