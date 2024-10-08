
using System.Data.SqlClient;
using System.Data;
using static AppDataBase.AdvertisementDB;

namespace AppDataBase
{
    public class AdvertisementDB : DataBase
    {
        public struct Car
        {
            public string Id;
            public string CarId;
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

        private string AddCar(Car car)
        {
            string carWasAdd = null;
            var connection = getConnection();


            string carQuery = $"INSERT INTO cars (car_name, car_price, car_mileage, car_type, car_imageurl) VALUES ('{car.Name}', '{car.Price}', '{car.MileAge}', '{car.CarType}', '{car.ImageUrl}')";
            var cmd = new SqlCommand(carQuery, connection);


            if (cmd.ExecuteNonQuery() == 1)
            {
                var reader = cmd.ExecuteReader();
                carWasAdd = reader["car_id"].ToString();
            }


            return carWasAdd;
        }

        public bool AddAdvertisement(Car car)
        {
            bool advertisementWasAdd = false;
            var connection = getConnection();

            openConnection();

            string carID = AddCar(car);

            if (carID != null)
            {
                string carQuery = $"INSERT INTO advertisements (advertisements_car, advertisements_views, advertisements_author) VALUES ('{carID}', '{car.Views}', '{car.AuthorLogin}')";
                var cmd = new SqlCommand(carQuery, connection);


                if (cmd.ExecuteNonQuery() == 1)
                {
                    advertisementWasAdd = true;
                }
            }

            

            closeConnection();

            return advertisementWasAdd;
        }

        public bool UpdateCar(Car car)
        {
            bool carWasUpdated = false;
            var connection = getConnection();

            openConnection();

            string userQuery = $"UPDATE advertisements SET advertisements_views = '{car.Views}' WHERE advertisements_id = '{car.Id}'";
            var cmd = new SqlCommand(userQuery, connection);


            if (cmd.ExecuteNonQuery() == 1)
            {
                carWasUpdated = true;
            }

            closeConnection();

            return carWasUpdated;
        }

        public bool DeleateCar(Car car)
        {
            bool carWasDeleated = false;
            var connection = getConnection();

            openConnection();

            string deleteQuery = "DELETE FROM Recipe WHERE Name_recipe = @Name_recipe";
            var cmd = new SqlCommand(deleteQuery, connection);


            if (cmd.ExecuteNonQuery() == 1)
            {
                carWasDeleated = true;
            }

            closeConnection();

            return carWasDeleated;
        }

        public ReturnCars GetAllCars()
        {
            ReturnCars returnCars = new()
            {
                carWasAdd = false,
                cars = new Car[9]
            };

            var connection = getConnection();

            openConnection();

            SqlDataAdapter advertiseAdapter = new();
            DataTable advertiseDT = new();

            string advertiseQuery = "SELECT advertisements_id, advertisements_car, advertisements_views, advertisements_author FROM advertisements";
            var advertiseCmd = new SqlCommand(advertiseQuery, connection);
            advertiseAdapter.SelectCommand = advertiseCmd;
            advertiseAdapter.Fill(advertiseDT);

            for (int i = 0; i < advertiseDT.Rows.Count; i++)
            {
                returnCars.cars[i].Id = advertiseDT.Rows[i]["advertisements_id"].ToString();
                returnCars.cars[i].CarId = advertiseDT.Rows[i]["advertisements_car"].ToString();
                returnCars.cars[i].Views = advertiseDT.Rows[i]["advertisements_views"].ToString();
                returnCars.cars[i].AuthorLogin = advertiseDT.Rows[i]["advertisements_author"].ToString();
            }

            SqlDataAdapter carAdapter = new();
            DataTable carDT = new();

            string carQuery = "SELECT car_name, car_price, car_mileage, car_type, car_imageurl FROM cars";
            var carCmd = new SqlCommand(carQuery, connection);
            carAdapter.SelectCommand = carCmd;
            carAdapter.Fill(carDT);

            for (int i = 0; i < carDT.Rows.Count; i++)
            {
                returnCars.cars[i].Name = carDT.Rows[i]["car_name"].ToString();
                returnCars.cars[i].Price = carDT.Rows[i]["car_price"].ToString();
                returnCars.cars[i].MileAge = carDT.Rows[i]["car_mileage"].ToString();
                returnCars.cars[i].CarType = carDT.Rows[i]["car_type"].ToString();
                returnCars.cars[i].ImageUrl = carDT.Rows[i]["car_imageurl"].ToString();

            }

            returnCars.carWasAdd = true;

            closeConnection();

            return returnCars;
        }
    }
}
