using Client.Interfaces.System;

namespace Client
{
    public partial class App : Application
    {
        public App(INavigationService navigationService)
        {
            InitializeComponent();

            navigationService.SetLoadingPageAsRoot();
        }
    }
}
