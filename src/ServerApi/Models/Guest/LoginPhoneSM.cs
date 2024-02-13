using System.Text.Json.Serialization;

namespace ServerApi.Models.Guest
{
    public class LoginPhoneSM
    {
        /// <summary>
        /// Gets or sets user's phone number
        /// </summary>
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets confirmation one-time code
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets fCM's token
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets id of user's device
        /// </summary>
        [JsonPropertyName("deviceId")]
        public string DeviceId { get; set; }
    }
}
