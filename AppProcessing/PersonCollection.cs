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

        public PersonElement CurrentSession = new();

        public bool CheckCorrectPerson(string login, string password)
        {
            foreach (PersonElement element in Persons) 
            {
                if (element.Login == login && element.Password == password) 
                { 
                    CurrentSession = element;
                    return true; 
                }
            }

            return false;
        }

        public bool LoginIsUnique(string login)
        {
            foreach (PersonElement element in Persons)
            {
                if (element.Login == login) return false;
            }

            return true;
        }
    }
}
