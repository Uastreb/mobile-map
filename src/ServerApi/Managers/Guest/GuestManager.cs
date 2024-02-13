using ServerApi.Extensions;
using ServerApi.Models.Guest;
using ServerApi.Routes;
using System.Net.Http.Json;

namespace ServerApi.Managers.Guest
{
    internal class GuestManager : IGuestManager
    {
        private readonly HttpClient _httpClient;

        public GuestManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc/>
        public async Task<TokenSM> LoginPhone(LoginPhoneSM phone)
        {
            var response = await _httpClient.PostAsJsonAsync(GuestRoutes.LoginPhoneRoute(), phone);
            var token = await response.GetResult<TokenSM>();

            return token;
        }

        /// <inheritdoc/>
        public async Task SendConfirmationCode(ConfirmationCodeSM code)
        {
            await _httpClient.PostAsJsonAsync(GuestRoutes.SendConfirmationCodeRoute(), code);
        }

        /// <inheritdoc/>
        public async Task<TokenSM> UpdateAccessToken(string refreshToken)
        {
            var token = await _httpClient.GetFromJsonAsync<TokenSM>(GuestRoutes.UpdateAccessTokenRoute(refreshToken));

            return token;
        }
    }
}
