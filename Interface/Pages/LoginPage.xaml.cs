using AppProcessing;

namespace Interface.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
        

		InitializeComponent();
	}

    public async void Login_Click(object sender, EventArgs args)
    {
        await Navigation.PushAsync(new MainPage());
    }

    public async void Register_Click(object sender, EventArgs args)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}