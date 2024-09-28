using AppProcessing;
using System.ComponentModel;
using System.Windows.Input;

namespace Interface.ViewModel
{
    internal class LoginViewModel :ViewModelBase
    {
        PersonElement personLogin;
        string notification;

        public LoginViewModel()
        {
            PersonLogin = new();
            PersonLogin.PropertyChanged += OnPersonEditPropertyChanged;
            LoginCommand = new Command(
                execute: () =>
                {

                    if (PersonCollection.Instance.CheckCorrectPerson(PersonLogin.Login, PersonLogin.Password))
                    { 
                        Shell.Current.GoToAsync("MainPage"); 
                    } else
                    {
                        Notification = "Неверный логин или пароль";
                    }

                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return PersonLogin != null &&
                           PersonLogin.Login != null &&
                           PersonLogin.Login.Length > 0 &&
                           PersonLogin.Password != null &&
                           PersonLogin.Password.Length > 0;
                });
            RegisterCommand = new Command(
                execute: () =>
                {
                    Shell.Current.GoToAsync("RegisterPage");
                    RefreshCanExecutes();
                });
        }

        void OnPersonEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            Notification = "";
            (LoginCommand as Command).ChangeCanExecute();
        }

        void RefreshCanExecutes()
        {
            (LoginCommand as Command).ChangeCanExecute();
            (RegisterCommand as Command).ChangeCanExecute();
        }

        public string Notification
        {
            set { SetProperty(ref notification, value); }
            get { return notification; }
        }

        public PersonElement PersonLogin
        {
            set { SetProperty(ref personLogin, value); }
            get { return personLogin; }
        }

        public ICommand LoginCommand { private set; get; }
        public ICommand RegisterCommand { private set; get; }
    }
}
