using Client.ViewModels;

namespace Client.Pages;

public partial class MenuPage : ContentPage
{
    private MenuViewModel _menuViewModel;

	public MenuPage()
	{
		InitializeComponent();
        
        this.Appearing += MenuPage_Appearing;
	}

    private void MenuPage_Appearing(object sender, EventArgs e)
    {
        _menuViewModel = BindingContext as MenuViewModel;
        _menuViewModel.OnInitialized();
    }
}