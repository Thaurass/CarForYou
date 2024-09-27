using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppProcessing;
using System.Windows.Input;

namespace Interface.ViewModel
{
    class RegisterViewModel : ViewModelBase
    {
        PersonElement personEdit;
        ViewModelBase _viewModelBase;

        public RegisterViewModel()
        {
            _viewModelBase = new();
            PersonEdit = new();
            PersonEdit.PropertyChanged += OnPersonEditPropertyChanged;
            SubmitCommand = new Command(
                execute: () =>
                {
                    PersonEdit.Views = 0;
                    PersonCollection.Instance.Persons.Add(PersonEdit);
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
            set { _viewModelBase.SetProperty(ref personEdit, value); }
            get { return personEdit; }
        }

        public ICommand SubmitCommand { private set; get; }

        
    }
}
