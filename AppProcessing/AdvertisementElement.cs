﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppProcessing
{
    public class AdvertisementElement : INotifyPropertyChanged
    {
        string name;
        string price;
        string mileAge;
        string carType; 
        int views;
        string imageUrl = "C:\\Users\\xj48v\\Burn2Code\\VS\\CarForYou\\Interface\\src\\car.jpg";

        public event PropertyChangedEventHandler PropertyChanged;

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

        public override string ToString()
        {
            return Name + ", price " + Price;
        }

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
