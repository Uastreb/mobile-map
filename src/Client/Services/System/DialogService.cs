using Client.Interfaces.System;

namespace Client.Services.System
{
    public class DialogService : IDialogService
    {
        private Page CurrPage => App.Current.MainPage.Navigation.NavigationStack.Last();

        /// <inheritdoc/>
        public async Task DisplayAlert(string title, string text, string buttonText)
        {
            await CurrPage.DisplayAlert(title, text, buttonText);
        }

        /// <inheritdoc/>
        public async Task<bool> DisplayAlert(string title, string text, string okButtonText, string cancelButtonText)
        {
            var result = await CurrPage.DisplayAlert(title, text, okButtonText, cancelButtonText);

            return result;
        }
    }
}
