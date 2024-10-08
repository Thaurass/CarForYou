
using System.Data.SqlClient;
using System.Data;
using static AppDataBase.AdvertisementDB;
using System.Transactions;

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
            cmd.ExecuteNonQuery();
            string query = $"SELECT car_id FROM cars WHERE car_name = '{car.Name}' AND car_price = '{car.Price}' AND car_mileage = '{car.MileAge}' AND car_type = '{car.CarType}' AND car_imageurl = '{car.ImageUrl}'";
            using (var cmd2 = new SqlCommand(query, connection))
            {
                carWasAdd = cmd2.ExecuteScalar().ToString();
                cmd2.ExecuteNonQuery();
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

        public bool DeleteCar(Car car)
        {
            bool carWasDeleated = false;
            var connection = getConnection();

            openConnection();

            string deleteAdvertiseQuery = $"DELETE FROM advertisements WHERE advertisements_id = '{car.Id}'";
            var cmdAdvertise = new SqlCommand(deleteAdvertiseQuery, connection);


            if (cmdAdvertise.ExecuteNonQuery() == 1)
            {
                string deleteCarQuery = $"DELETE FROM cars WHERE car_id = '{car.CarId}'";
                var cmdCar = new SqlCommand(deleteCarQuery, connection);


                if (cmdCar.ExecuteNonQuery() == 1)
                {
                    carWasDeleated = true;
                }
            }

            

            closeConnection();

            return carWasDeleated;
        }

        public ReturnCars GetAllCars()
        {
            ReturnCars returnCars = new()
            {
                carWasAdd = false
            };

            var connection = getConnection();

            openConnection();

            SqlDataAdapter advertiseAdapter = new();
            DataTable advertiseDT = new();

            string advertiseQuery = "SELECT advertisements_id, advertisements_car, advertisements_views, advertisements_author FROM advertisements";
            var advertiseCmd = new SqlCommand(advertiseQuery, connection);
            
            advertiseAdapter.SelectCommand = advertiseCmd;
            advertiseAdapter.Fill(advertiseDT);

            returnCars.cars = new Car[advertiseDT.Rows.Count];
            for (int i = 0; i < advertiseDT.Rows.Count; i++)
            {
                returnCars.cars[i].Id = advertiseDT.Rows[i]["advertisements_id"].ToString();
                returnCars.cars[i].CarId = advertiseDT.Rows[i]["advertisements_car"].ToString();
                returnCars.cars[i].Views = advertiseDT.Rows[i]["advertisements_views"].ToString();
                returnCars.cars[i].AuthorLogin = advertiseDT.Rows[i]["advertisements_author"].ToString();
            }

            SqlDataAdapter carAdapter = new();
            DataTable carDT = new();
            advertiseCmd.ExecuteNonQuery();

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
            carCmd.ExecuteNonQuery();


            returnCars.carWasAdd = true;

            closeConnection();

            return returnCars;
        }
    }
}
