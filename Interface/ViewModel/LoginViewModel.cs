using AppProcessing;
using Interface.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interface.ViewModel
{
    public class LoginViewModel :ViewModelBase
    {
        PersonElement personEdit;

        public LoginViewModel()
        {
            PersonEdit = new();
            PersonEdit.PropertyChanged += OnPersonEditPropertyChanged;
            LoginCommand = new Command(
                execute: () =>
                {
                    Shell.Current.GoToAsync("..");
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return PersonEdit != null &&
                           PersonEdit.Name != null &&
                           PersonEdit.Name.Length > 0 &&
                           PersonEdit.Password != null &&
                           PersonEdit.Password.Length > 0;
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
            (LoginCommand as Command).ChangeCanExecute();
        }

        void RefreshCanExecutes()
        {
            (LoginCommand as Command).ChangeCanExecute();
            (RegisterCommand as Command).ChangeCanExecute();
        }

        public PersonElement PersonEdit
        {
            set { SetProperty(ref personEdit, value); }
            get { return personEdit; }
        }

        public ICommand LoginCommand { private set; get; }
        public ICommand RegisterCommand { private set; get; }
    }
}
