using System.Text.Json.Serialization;

namespace TokenCachingExample;

public class TokenResult
{
    [JsonPropertyName("access_token")] public string AccessToken { get; set; }
    [JsonPropertyName("scope")] public string Scope { get; set; }
    [JsonPropertyName("expires_in")] public int SecondsUntilExpiration { get; set; }
    [JsonPropertyName("token_type")] public string TokenType { get; set; }
}