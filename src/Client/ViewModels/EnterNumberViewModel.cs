using Client.Constants;
using Client.Interfaces.System;
using Client.Pages.Login;
using Client.ViewModels.Base;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels
{
    public class EnterNumberViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public EnterNumberViewModel(INavigationService navigationService, IServiceProvider serviceProvider) : base(serviceProvider)
        { 
            _navigationService = navigationService;
        }

        public string PhoneNumber { get; set; }
        public bool AgreeWithPrivacyPolicy { get; set; }

        [Bindable]
        public bool FormIsValid { get; set; }

        public IAsyncRelayCommand EnterPhoneCommand => new AsyncRelayCommand(EnterPhone);
        
        public void ValidateForm()
        {
            var phone = PhoneNumber?.Trim().TrimStart('+');
            var phoneIsValid = !string.IsNullOrEmpty(phone) && phone.Length > ValidationConstants.MinPhoneLength && phone.Length < ValidationConstants.MaxPhoneLength;

            FormIsValid = phoneIsValid && AgreeWithPrivacyPolicy;

            StateHasChanged();
        }

        public async Task EnterPhone()
        {
            await _navigationService.NavigateToPage<EnterCodePage, EnterCodeViewModel, string>(PhoneNumber.Trim());
        }
    }
}
