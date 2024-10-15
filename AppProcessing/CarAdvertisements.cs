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

        public bool carWasAdd;
        public bool carsWasUpdated;
        public bool carsWasDeleate;

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
                newCar.CarId = element.CarId;
                newCar.Name = element.Name;
                newCar.Price = element.Price;
                newCar.MileAge = element.MileAge;
                newCar.CarType = element.CarType;
                if(element.Views != null)
                {
                    newCar.Views = Int32.Parse(element.Views);

                }
                newCar.ImageUrl = element.ImageUrl;
                newCar.AuthorLogin = element.AuthorLogin;
                Cars.Add(newCar);
            }
            

            return newCars.carWasAdd;
        }

        async public Task AddCar(AdvertisementElement element)
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

            carWasAdd = await Task.Run(() => advertisementDB.AddAdvertisement(car));
            updateAllCars();

        }

        async public Task UpdateOneCar(AdvertisementElement element)
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

            carsWasUpdated = await Task.Run(() => advertisementDB.UpdateCar(car));
            updateAllCars();

        }

        async public Task DeleteOneCar(AdvertisementElement element)
        {
            Car car = new Car();
            car.Id = element.Id;
            car.CarId = element.CarId;
            car.Name = element.Name;
            car.Price = element.Price;
            car.MileAge = element.MileAge;
            car.CarType = element.CarType;
            car.Views = element.Views.ToString();
            car.ImageUrl = element.ImageUrl;
            car.AuthorLogin = element.AuthorLogin;

            carsWasDeleate = await Task.Run(() => advertisementDB.DeleteCar(car));
            updateAllCars();

        }
    }

}
