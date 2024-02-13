using Client.Interfaces.Entity;
using Client.Interfaces.System;
using Client.ViewModels.Base;

namespace Client.ViewModels
{
    internal class LoadingPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ITokenService _tokenService;

        public LoadingPageViewModel(IServiceProvider serviceProvider, INavigationService navigationService, ITokenService tokenService) : base(serviceProvider)
        {
            _navigationService = navigationService;
            _tokenService = tokenService;
        }

        public override async void OnInitialized()
        {
            var token = await _tokenService.GetToken();
            if (token != default)
            {
                _navigationService.SetMenuPageAsRoot();
            }
            else
            {
                _navigationService.SetLoginPageAsRoot();
            }
        }
    }
}
