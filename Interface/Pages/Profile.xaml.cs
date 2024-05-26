using AppProcessing;

namespace Interface.Pages;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
	}
    public void Advertise_Click(object sender, EventArgs args)
    {
        advertise.Text = CarAdvertisements.Advertisements[0].Name;
    }
}