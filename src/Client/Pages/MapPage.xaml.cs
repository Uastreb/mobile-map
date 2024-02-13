using Client.ViewModels;

namespace Client.Pages;

public partial class MapPage : ContentPage
{
    private MapViewModel _mapViewModel;

	public MapPage()
	{
		InitializeComponent();
        this.Appearing += MapPage_Appearing;
	}

    private void MapPage_Appearing(object sender, EventArgs e)
    {
        _mapViewModel = BindingContext as MapViewModel;
        _mapViewModel.OnInitialized();
    }
}