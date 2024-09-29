
using System.Data;
using System.Data.SqlClient;

namespace AppDataBase
{
    public class PersonDB : DataBase
    {

        public struct User 
        {
            public string Name;
            public string Login;
            public string Password;
            public string Views;
        }

        public struct ReturnUsers
        {
            public User[] users;
            public bool userWasAdd; 
        }

        public bool AddUser(User user)
        {
            bool userWasAdd = false;
            
            using (var connection = getConnection())
            {

                openConnection();

                string userQuery = $"INSERT INTO persons (person_name, person_login, person_password, person_views) VALUES ('{user.Name}', '{user.Login}', '{user.Password}', '{user.Views}')";
                var cmd = new SqlCommand(userQuery, connection);

                userWasAdd = true;


                closeConnection();
            }
            
            return userWasAdd;
        }

        public ReturnUsers GetAllUsers()
        {
            ReturnUsers returnUsers = new();

            returnUsers.userWasAdd = false;
            
            using (var connection = getConnection())
            {

                openConnection();

                SqlDataAdapter adapter = new();
                DataTable dt = new();

                string userQuery = "SELECT person_name, person_login, person_password, person_views FROM persons";
                var cmd = new SqlCommand(userQuery, connection);
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);

                returnUsers.users = new User[dt.Rows.Count];
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    returnUsers.users[i].Name = dt.Rows[i]["person_name"].ToString();
                    returnUsers.users[i].Login = dt.Rows[i]["person_login"].ToString();
                    returnUsers.users[i].Password = dt.Rows[i]["person_password"].ToString();
                    returnUsers.users[i].Views = dt.Rows[i]["person_views"].ToString();

                }

                returnUsers.userWasAdd = true;

                closeConnection();
            }
            
            return returnUsers;
        }




        //public User GetUserByLogin(string login)
        //{
        //    User user = new();

        //    using (var connection = DataBase.Instance.getConnection())
        //    {
        //        DataBase.Instance.openConnection();
        //        string query = "SELECT ID_user, FIO, Login, Password FROM User_ WHERE Login = @Login";
        //        using (var cmd = new SqlCommand(query, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@Login", login);
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    user = new User(
        //                        reader["FIO"].ToString(),
        //                        reader["Login"].ToString(),
        //                        reader["Password"].ToString()
        //                        )
        //                    {
        //                        ID_user = (int)reader["ID_user"]
        //                    };

        //                }
        //            }
        //        }
        //        DataBase.Instance.closeConnection();
        //    }

        //    return user;
        //}
    }
}
