
using System.Data.SqlClient;
using System.Data;

namespace AppDataBase
{
    public class AdvertisementDB : DataBase
    {
        public struct Car
        {
            public string Id;
            public string Name;
            public string Price;
            public string MileAge;
            public string CarType;
            public string Views;
            public string ImageUrl;
            public string AuthorLogin;

        }

        public struct ReturnCars
        {
            public Car[] cars;
            public bool carWasAdd;
        }

        public bool AddCar(Car car)
        {
            bool userWasAdd = false;
            var connection = getConnection();

            openConnection();

            string userQuery = $"INSERT INTO advertisements (advertisements_name, advertisements_price, advertisements_mileage, advertisements_cartype, advertisements_views, advertisements_carimage, advertisements_author, advertisements_imageurl) VALUES ('{car.Name}', '{car.Price}', '{car.MileAge}', '{car.CarType}', '{car.Views}', 0, '{car.AuthorLogin}', '{car.ImageUrl}')";
            var cmd = new SqlCommand(userQuery, connection);


            if (cmd.ExecuteNonQuery() == 1)
            {
                userWasAdd = true;
            }

            closeConnection();

            return userWasAdd;
        }

        public bool UpdateCar(Car car)
        {
            bool userWasUpdated = false;
            var connection = getConnection();

            openConnection();

            string userQuery = $"UPDATE advertisements SET advertisements_views = '{car.Views}' WHERE advertisements_id = '{car.Id}'";
            var cmd = new SqlCommand(userQuery, connection);


            if (cmd.ExecuteNonQuery() == 1)
            {
                userWasUpdated = true;
            }

            closeConnection();

            return userWasUpdated;
        }

        public ReturnCars GetAllCars()
        {
            ReturnCars returnCars = new();

            returnCars.carWasAdd = false;

            var connection = getConnection();

            openConnection();

            SqlDataAdapter adapter = new();
            DataTable dt = new();

            string userQuery = "SELECT advertisements_id, advertisements_name, advertisements_price, advertisements_mileage, advertisements_cartype, advertisements_views, advertisements_author, advertisements_imageurl FROM advertisements";
            var cmd = new SqlCommand(userQuery, connection);
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            returnCars.cars = new Car[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                returnCars.cars[i].Id = dt.Rows[i]["advertisements_id"].ToString();
                returnCars.cars[i].Name = dt.Rows[i]["advertisements_name"].ToString();
                returnCars.cars[i].Price = dt.Rows[i]["advertisements_price"].ToString();
                returnCars.cars[i].MileAge = dt.Rows[i]["advertisements_mileage"].ToString();
                returnCars.cars[i].CarType = dt.Rows[i]["advertisements_cartype"].ToString();
                returnCars.cars[i].Views = dt.Rows[i]["advertisements_views"].ToString();
                returnCars.cars[i].AuthorLogin = dt.Rows[i]["advertisements_author"].ToString();
                returnCars.cars[i].ImageUrl = dt.Rows[i]["advertisements_imageurl"].ToString();
            }

            returnCars.carWasAdd = true;

            closeConnection();

            return returnCars;
        }
    }
}
