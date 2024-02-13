using System.Text.Json.Serialization;

namespace ServerApi.Models
{
    public class ErrorModel
    {
        /// <summary>
        /// </summary>
        [JsonPropertyName("code")]
        public int? Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
