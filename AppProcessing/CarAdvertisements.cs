using AppDataBase;
using System.Collections.ObjectModel;
using static AppDataBase.AdvertisementDB;

namespace AppProcessing
{
    public class CarAdvertisements
    {
        private static CarAdvertisements? _instance;
        public static CarAdvertisements Instance => _instance ??= new CarAdvertisements();
        //"C:\\Users\\xj48v\\Burn2Code\\CarForYou\\Interface\\src\\car.jpg"

        public IList<AdvertisementElement> Cars { get; set;  } = new ObservableCollection<AdvertisementElement>();
        AdvertisementDB advertisementDB = new();

        public bool updateAllCars()
        {
            ReturnCars newCars = advertisementDB.GetAllCars();
            Cars = new ObservableCollection<AdvertisementElement>();

            foreach (Car element in newCars.cars)
            {
                AdvertisementElement newCar = new();
                newCar.Id = element.Id;
                newCar.Name = element.Name;
                newCar.Price = element.Price;
                newCar.MileAge = element.MileAge;
                newCar.CarType = element.CarType;
                newCar.Views = Int32.Parse(element.Views);
                newCar.ImageUrl = element.ImageUrl;
                newCar.AuthorLogin = element.AuthorLogin;
                Cars.Add(newCar);
            }

            return newCars.carWasAdd;
        }

        public bool AddCar(AdvertisementElement element)
        {
            Car car = new Car();
            car.Id = element.Id;
            car.Name = element.Name;
            car.Price = element.Price;
            car.MileAge = element.MileAge;
            car.CarType = element.CarType;
            car.Views = element.Views.ToString();
            car.ImageUrl = element.ImageUrl;
            car.AuthorLogin = element.AuthorLogin;

            bool carWasAdd = advertisementDB.AddCar(car);
            updateAllCars();

            return carWasAdd;
        }

        public bool UpdateOneCar(AdvertisementElement element)
        {
            Car car = new Car();
            car.Id = element.Id;
            car.Name = element.Name;
            car.Price = element.Price;
            car.MileAge = element.MileAge;
            car.CarType = element.CarType;
            car.Views = element.Views.ToString();
            car.ImageUrl = element.ImageUrl;
            car.AuthorLogin = element.AuthorLogin;

            bool carsWasUpdated = advertisementDB.UpdateCar(car);
            updateAllCars();

            return carsWasUpdated;
        }

        public bool DeleateOneCar(AdvertisementElement element)
        {
            Car car = new Car();
            car.Id = element.Id;
            car.Name = element.Name;
            car.Price = element.Price;
            car.MileAge = element.MileAge;
            car.CarType = element.CarType;
            car.Views = element.Views.ToString();
            car.ImageUrl = element.ImageUrl;
            car.AuthorLogin = element.AuthorLogin;

            bool carsWasDeleated = advertisementDB.DeleateCar(car);
            updateAllCars();

            return carsWasDeleated;
        }
    }

}
