﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppProcessing;
using System.Windows.Input;

namespace Interface.ViewModel
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        PersonElement personEdit;
        bool isEditing;

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterViewModel()
        {
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
                           PersonEdit.Password != null;
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

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
