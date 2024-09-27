using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        public int Views
        {
            set { SetProperty(ref views, value); }
            get { return views; }
        }

        public override string ToString()
        {
            return Name + ", views " + views;
        }
    }
}
