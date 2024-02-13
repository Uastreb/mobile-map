using Client.Interfaces.Entity;
using Client.Interfaces.System;
using Client.ViewModels.Base;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly IUserService _userProfileService;
        private readonly IIdentityService _identityService;
        private readonly INavigationService _navigationService;

        public MenuViewModel(IServiceProvider serviceProvider, IUserService userProfileService, IIdentityService identityService, INavigationService navigationService) : base(serviceProvider)
        {
            _userProfileService = userProfileService;
            _identityService = identityService;
            _navigationService = navigationService;
        }

        [Bindable]
        public string PhoneNumber { get; set; }

        public IAsyncRelayCommand LogoutCommand => new AsyncRelayCommand(Logout);

        public override async void OnInitialized()
        {
            await SafeExecuteAsync(async () =>
            {
                var user = await _userProfileService.GetPofile();
                PhoneNumber = user.PhoneNumber;
            });

            StateHasChanged();
        }

        public async Task Logout()
        {
            await SafeExecuteAsync(async () =>
            {
                await _identityService.Logout();
                _navigationService.SetLoginPageAsRoot();
            });
        }
    }
}
