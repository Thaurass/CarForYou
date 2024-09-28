using AppProcessing;
using System.Windows.Input;

namespace Interface.ViewModel
{
    internal class ProfileViewModel : ViewModelBase
    {
        string name;
        string login;
        string password;

        public ProfileViewModel()
        {
            Name = PersonCollection.Instance.CurrentSession.Name;
            Login = PersonCollection.Instance.CurrentSession.Login;
        }

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

        public ICommand ChangeNameCommand { private set; get; }
        public ICommand ChangePassCommand { private set; get; }

    }
}
