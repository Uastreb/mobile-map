using System.Text.Json.Serialization;

namespace ServerApi.Models.Guest
{
    public class TokenSM
    {
        /// <summary>
        /// Gets or sets access token (short term)
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets refresh token (long term)
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
