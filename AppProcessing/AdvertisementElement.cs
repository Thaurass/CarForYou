

namespace AppProcessing
{
    public class AdvertisementElement : ViewModelBase
    {
        string id;
        string name;
        string price;
        string mileAge;
        string carType; 
        int views;
        string imageUrl = "C:\\Users\\xj48v\\Burn2Code\\VS\\CarForYou\\Interface\\src\\car.jpg";
        string authorLogin;

        public string Id
        {
            set { SetProperty(ref id, value); }
            get { return id; }
        }
        public string Name
        {
            set { SetProperty(ref name, value); }
            get { return name; }
        }

        public string Price
        {
            set { SetProperty(ref price, value); }
            get { return price; }
        }

        public string MileAge
        {
            set { SetProperty(ref mileAge, value); }
            get { return mileAge; }
        }

        public string CarType
        {
            set { SetProperty(ref carType, value); }
            get { return carType; }
        }

        public int Views
        {
            set { SetProperty(ref views, value); }
            get { return views; }
        }

        public string ImageUrl
        {
            set { SetProperty(ref imageUrl, value); }
            get { return imageUrl; }
        }

        public string AuthorLogin
        {
            set { SetProperty(ref authorLogin, value); }
            get { return authorLogin; }
        }



        public override string ToString()
        {
            return Name + ", price " + Price;
        }

    }
}
