using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProcessing
{
    public class PersonCollection
    {
        private static PersonCollection? _instance;
        public static PersonCollection Instance => _instance ??= new PersonCollection();
        //"C:\\Users\\xj48v\\Burn2Code\\CarForYou\\Interface\\src\\car.jpg"

        public IList<PersonElement> Persons { get; } = new ObservableCollection<PersonElement>();
    }
}
