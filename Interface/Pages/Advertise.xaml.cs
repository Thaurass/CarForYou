using AppProcessing;

namespace Interface.Pages;

public partial class Advertise : ContentPage
{
    public Advertise()
	{
        CarAdvertisements.CreateAdvertisements();
        InitializeComponent();
	}

    public void Advertise_Click(object sender, EventArgs args)
    {
        CarAdvertisements.AddAdvertisement(nameEntry.Text, priceEntry.Text, mileAgeEntry.Text, carTypeEntry.Text, "C:\\Users\\xj48v\\Burn2Code\\CarForYou\\Interface\\src\\car.jpg");
    }
}