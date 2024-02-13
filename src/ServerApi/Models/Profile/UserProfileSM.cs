using System.Text.Json.Serialization;

namespace ServerApi.Models.Profile
{
    public class UserProfileSM
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets email
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets date of registration
        /// </summary>
        [JsonPropertyName("registrationDate")]
        public long? RegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets phone number
        /// </summary>
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets link to the avatar
        /// </summary>
        [JsonPropertyName("pathToAvatar")]
        public string PathToAvatar { get; private set; }
    }
}
