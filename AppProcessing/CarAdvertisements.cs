using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProcessing
{
    public static class CarAdvertisements
    {
        //"C:\\Users\\xj48v\\Burn2Code\\CarForYou\\Interface\\src\\car.jpg"

        public static IList<AdvertisementElement> Cars { get; } = new ObservableCollection<AdvertisementElement>();

    }

}
