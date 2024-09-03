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
        advertise.Text = CarAdvertisements.Advertisements[0].Name +
             CarAdvertisements.Advertisements[0].MileAge +
             CarAdvertisements.Advertisements[0].CarType +
             CarAdvertisements.Advertisements[0].Price +
             CarAdvertisements.Advertisements[0].Views +
             CarAdvertisements.Advertisements[0].ImageUrl;
    }
}