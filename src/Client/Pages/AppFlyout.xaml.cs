using Client.ViewModels;

namespace Client.Pages;

public partial class AppFlyout : FlyoutPage
{
	public AppFlyout(MenuViewModel menuVM, MapViewModel mapVM)
	{
		InitializeComponent();

		menuPage.BindingContext = menuVM;
		mapPage.BindingContext = mapVM;
	}
}