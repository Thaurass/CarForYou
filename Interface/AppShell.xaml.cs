﻿using Interface.Pages;

namespace Interface
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        }
    }
}
