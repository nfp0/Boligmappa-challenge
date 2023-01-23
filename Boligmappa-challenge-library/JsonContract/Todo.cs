using System.Text.Json.Serialization;

namespace Boligmappa_challenge_library.JsonContract
{
    public class Todo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("todo")]
        public string TodoMessage { get; set; }

        [JsonPropertyName("completed")]
        public bool Completed { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }
    }
}