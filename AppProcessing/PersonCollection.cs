
using System.Collections.ObjectModel;
using AppDataBase;
using static AppDataBase.PersonDB;


namespace AppProcessing
{
    public class PersonCollection
    {
        private static PersonCollection? _instance;
        public static PersonCollection Instance => _instance ??= new PersonCollection();

        private IList<PersonElement> Persons { get; set; } = new ObservableCollection<PersonElement>();
        public PersonElement CurrentSession = new();
        private PersonDB personDB = new();

        public bool CheckCorrectPerson(string login, string password)
        {
            updateAllPersons();
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
            updateAllPersons();
            foreach (PersonElement element in Persons)
            {
                if (element.Login == login) return false;
            }

            return true;
        }

        public bool updateAllPersons() 
        {
            ReturnUsers newUsers = personDB.GetAllUsers();
            Persons = new ObservableCollection<PersonElement>();

            foreach (User element in newUsers.users) 
            { 
                PersonElement newPerson = new();
                newPerson.Name = element.Name;
                newPerson.Login = element.Login;
                newPerson.Password = element.Password;
                newPerson.Views = Int32.Parse(element.Views);
                Persons.Add(newPerson);
            }

            return newUsers.userWasAdd;
        }

        public bool AddPerson(PersonElement element)
        {
            User user = new User();
            user.Name = element.Name;
            user.Login = element.Login;
            user.Password = element.Password;
            user.Views = element.Views.ToString();

            bool personWasAdd = personDB.AddUser(user);
            updateAllPersons();

            return personWasAdd;
        }

        public bool UpdateOnePerson(PersonElement element)
        {
            User user = new User();
            user.Name = element.Name;
            user.Login = element.Login;
            user.Password = element.Password;
            user.Views = element.Views.ToString();

            bool personWasUpdated = personDB.UpdateUser(user);
            updateAllPersons();

            return personWasUpdated;
        }
    }
}
