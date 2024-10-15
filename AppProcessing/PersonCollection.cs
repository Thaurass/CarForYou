
using System.Collections.ObjectModel;
using AppDataBase;
using static AppDataBase.PersonDB;


namespace AppProcessing
{
    public class PersonCollection
    {
        private static PersonCollection? _instance;
        public static PersonCollection Instance => _instance ??= new PersonCollection();

        public bool personWasAdd;

        public IList<PersonElement> Persons { get; set; } = new ObservableCollection<PersonElement>();
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
                Persons.Add(newPerson);
            }

            return newUsers.userWasAdd;
        }

        async public Task AddPerson(PersonElement element)
        {
            User user = new User();
            user.Name = element.Name;
            user.Login = element.Login;
            user.Password = element.Password;

            personWasAdd = await Task.Run(() => personDB.AddUser(user));
            updateAllPersons();

        }

        async public Task UpdateOnePerson(PersonElement element)
        {
            User user = new User();
            user.Name = element.Name;
            user.Login = element.Login;
            user.Password = element.Password;

            bool personWasUpdated = await Task.Run(() => personDB.UpdateUser(user));
            updateAllPersons();

        }
    }
}
