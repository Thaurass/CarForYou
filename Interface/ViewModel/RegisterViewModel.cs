using System.ComponentModel;
using AppProcessing;
using System.Windows.Input;

namespace Interface.ViewModel
{
    internal class RegisterViewModel : ViewModelBase
    {
        PersonElement personEdit;
        string notification;

        public RegisterViewModel()
        {
            PersonEdit = new();
            PersonEdit.PropertyChanged += OnPersonEditPropertyChanged;
            SubmitCommand = new Command(
                execute: () =>
                {
                    if(PersonCollection.Instance.LoginIsUnique(PersonEdit.Login))
                    {
                        PersonCollection.Instance.AddPerson(PersonEdit);
                        Notification = "Пользователь успешно зарегестрирован";
                    } else
                    {
                        Notification = "Данный логин занят";
                    }
                    
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return PersonEdit != null &&
                           PersonEdit.Name != null &&
                           PersonEdit.Name.Length > 1 &&
                           PersonEdit.Login != null &&
                           PersonEdit.Login.Length > 1 &&
                           PersonEdit.Password != null &&
                           PersonEdit.Password.Length > 1;
                });

        }

        void OnPersonEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            Notification = "";
            (SubmitCommand as Command).ChangeCanExecute();
        }

        void RefreshCanExecutes()
        {
            (SubmitCommand as Command).ChangeCanExecute();
        }

        public string Notification
        {
            set { SetProperty(ref notification, value); }
            get { return notification; }
        }

        public PersonElement PersonEdit
        {
            set { SetProperty(ref personEdit, value); }
            get { return personEdit; }
        }

        public ICommand SubmitCommand { private set; get; }

        
    }
}
