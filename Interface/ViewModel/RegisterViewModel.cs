using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppProcessing;
using System.Windows.Input;
using Interface.Pages;

namespace Interface.ViewModel
{
    class RegisterViewModel : ViewModelBase
    {
        PersonElement personEdit;

        public RegisterViewModel()
        {
            PersonEdit = new();
            PersonEdit.PropertyChanged += OnPersonEditPropertyChanged;
            SubmitCommand = new Command(
                execute: () =>
                {
                    PersonEdit.Views = 0;
                    PersonCollection.Instance.Persons.Add(PersonEdit);
                    Shell.Current.GoToAsync("LoginPage");
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
            (SubmitCommand as Command).ChangeCanExecute();
        }

        void RefreshCanExecutes()
        {
            (SubmitCommand as Command).ChangeCanExecute();
        }

        public PersonElement PersonEdit
        {
            set { SetProperty(ref personEdit, value); }
            get { return personEdit; }
        }

        public ICommand SubmitCommand { private set; get; }

        
    }
}
