using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProcessing
{
    public class CarAdvertisements
    {
        private static CarAdvertisements? _instance;
        public static CarAdvertisements Instance => _instance ??= new CarAdvertisements();
        //"C:\\Users\\xj48v\\Burn2Code\\CarForYou\\Interface\\src\\car.jpg"

        public IList<AdvertisementElement> Cars { get; } = new ObservableCollection<AdvertisementElement>();

        public void AddView(int index)
        {
            Cars[index].Views++;
        }

    }

}
