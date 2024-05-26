using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProcessing
{
    public class CarAdvertisements
    {
        //"C:\\Users\\xj48v\\Burn2Code\\CarForYou\\Interface\\src\\car.jpg"
        public static List<Advertisement> Advertisements { get; set; }

        public static bool AddAdvertisement(string name, string price, string mileAge, string carType, string imageUrl)
        {
            Advertisements.Add(new Advertisement(name, price, mileAge, carType, 0, imageUrl));

            return true;
        }

        public static void CreateAdvertisements()
        {
            Advertisements = new();
        }
    }
    
    public class Advertisement
    {
        public Advertisement(string name, string price, string mileAge, string carType, int views, string imageUrl)
        {
            Name = name;
            Price = price;
            MileAge = mileAge;
            CarType = carType;
            Views = views;
            ImageUrl = imageUrl;
        }
        public string Name { get; set; }
        public string Price { get; set; }
        public string MileAge { get; set; }
        public string CarType { get; set; }
        public int Views { get; set; }
        public string ImageUrl { get; set; }
    }
}
