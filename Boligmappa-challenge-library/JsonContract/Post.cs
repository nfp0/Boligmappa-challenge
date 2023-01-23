using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Boligmappa_challenge_library.JsonContract
{
    public class Post
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("reactions")]
        public int Reactions { get; set; }
    }
}