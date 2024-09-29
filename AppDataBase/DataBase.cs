using System.Data.SqlClient;

namespace AppDataBase
{
    public class DataBase
    {
        private static DataBase? _instance;
        public static DataBase Instance => _instance ??= new DataBase();

        private readonly SqlConnection _sqlConnection;

        public DataBase()
        {
            _sqlConnection = new SqlConnection(@"Data Source=PERSESMA\SQLEXPRESS;Initial Catalog=CarForYouDB;Integrated Security=True");
        }

        public void openConnection()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Open)
            {
                _sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return _sqlConnection;
        }
    }
}
