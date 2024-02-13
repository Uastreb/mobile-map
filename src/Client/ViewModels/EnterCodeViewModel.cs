using Client.Constants;
using Client.Interfaces.Entity;
using Client.Interfaces.System;
using Client.ViewModels.Base;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels
{
    public class EnterCodeViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IIdentityService _identityService;

        public EnterCodeViewModel(INavigationService navigationService, IIdentityService identityService, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _navigationService = navigationService;
            _identityService = identityService;
        }

        public string Code { get; set; }
        public string PhoneNumber { get; set; }
        public TimeSpan TimerValue { get; set; }

        [Bindable]
        public bool FormIsValid { get; set; }

        public IRelayCommand LoginCommand => new AsyncRelayCommand(Login);

        public override async void OnInitialized()
        {
            PhoneNumber = GetParam<string>();

            await SendCode();
        }

        public void ValidateForm()
        {
            var code = Code?.Trim();
            var codeIsValid = !string.IsNullOrEmpty(code) && code.Length == ValidationConstants.VerificationCodeLenght;
            var timerTimeIsValid = TimerValue > TimeSpan.Zero;

            FormIsValid = codeIsValid && timerTimeIsValid;

            StateHasChanged();
        }

        public async Task SendCode()
        {
            await SafeExecuteAsync(async () => 
            { 
                await _identityService.SendConfirmationCode(PhoneNumber);
            });
        }

        public async Task Login()
        {
            var code = Code.Trim();
            var checkExecute = await SafeExecuteAsync(async () =>
            {
                await _identityService.Login(PhoneNumber, code);
                _navigationService.SetMenuPageAsRoot();
            });
        }
    }
}
