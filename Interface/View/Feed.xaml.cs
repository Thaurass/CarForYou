
using Interface.ViewModel;

namespace Interface.Pages;

public partial class Feed : ContentPage
{
    public Feed()
	{
        InitializeComponent();
    }

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        FeedViewModel.Instance.SelectCar(e.ItemIndex);
    }

}