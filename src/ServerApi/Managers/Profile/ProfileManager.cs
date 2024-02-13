using ServerApi.Models.Profile;
using ServerApi.Routes;
using System.Net.Http.Json;

namespace ServerApi.Managers.Profile
{
    internal class ProfileManager : IProfileManager
    {
        private readonly HttpClient _httpClient;

        public ProfileManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc/>
        public async Task<UserProfileSM> GetProfile()
        {
            var profile = await _httpClient.GetFromJsonAsync<UserProfileSM>(ProfileRoutes.GetProfileRoute());
            
            return profile;
        }

        /// <inheritdoc/>
        public async Task Logout()
        {
            await _httpClient.GetAsync(ProfileRoutes.GetProfileRoute());
        }
    }
}
