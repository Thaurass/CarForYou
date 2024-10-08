
namespace AppProcessing
{
    public class PersonElement : ViewModelBase
    {

        
        string name;
        string login;
        string password;
        int views;

        public string Name
        {
            set { SetProperty(ref name, value); }
            get { return name; }
        }

        public string Login
        {
            set { SetProperty(ref login, value); }
            get { return login; }
        }

        public string Password
        {
            set { SetProperty(ref password, value); }
            get { return password; }
        }


        public override string ToString()
        {
            return Name + ", views " + views;
        }
    }
}
