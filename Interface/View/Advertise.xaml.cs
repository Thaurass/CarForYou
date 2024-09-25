using AppProcessing;

namespace Interface.Pages;

public partial class Advertise : ContentPage
{
    public Advertise()
	{
        InitializeComponent();
	}

    public void Advertise_Click(object sender, EventArgs args)
    {
        CarAdvertisements.AddAdvertisement(nameEntry.Text, priceEntry.Text, mileAgeEntry.Text, carTypeEntry.Text, "C:\\Users\\xj48v\\Burn2Code\\VS\\CarForYou\\Interface\\src\\car.jpg");
    }
}