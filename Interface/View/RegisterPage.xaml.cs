namespace Interface.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();

    }

    protected override bool OnBackButtonPressed() 
    {
        return false;
    }


    public async void Register_Click(object sender, EventArgs args)
    {
        await Navigation.PopAsync();
    }
}