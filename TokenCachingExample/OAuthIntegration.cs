using RestSharp;

namespace TokenCachingExample;

public interface IOAuthIntegration
{
    Task<TokenResult> GetCloudToken();
}

public class OAuthIntegration(IConfiguration configuration) : IOAuthIntegration
{
    public async Task<TokenResult> GetCloudToken()
    {
        var client = new RestClient(configuration["Auth:Url"]!);
        var request = new RestRequest("/oauth/token", Method.Post);
        request.AddJsonBody(new
        {
            grant_type = "client_credentials",
            client_id = configuration["Auth:ClientId"],
            client_secret = configuration["Auth:ClientSecret"],
            audience = configuration["Auth:Audience"]
        });
        var response = await client.ExecuteAsync<TokenResult>(request);
        if (response is not { IsSuccessful: true, Data: not null }) throw new Exception($"Failed to get token: {response.ErrorMessage}");
        return response.Data;
    }
}