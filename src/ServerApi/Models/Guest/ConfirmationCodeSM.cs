using System.Text.Json.Serialization;

namespace ServerApi.Models.Guest
{
    public class ConfirmationCodeSM
    {
        /// <summary>
        /// Gets or sets user's phone number
        /// </summary>
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
