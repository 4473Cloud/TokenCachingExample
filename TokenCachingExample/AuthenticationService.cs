using Microsoft.Extensions.Caching.Memory;

namespace TokenCachingExample;

public interface IAuthenticationService
{
    Task<TokenResult> GetToken();
}

public class AuthenticationService(IMemoryCache memoryCache, IOAuthIntegration oAuthIntegration) : IAuthenticationService
{
    public async Task<TokenResult> GetToken()
    {
        if (memoryCache.TryGetValue("AuthToken", out TokenResult? cachedToken) && cachedToken != null)
            return cachedToken;

        var tokenResult = await oAuthIntegration.GetCloudToken();
        //The subtraction of 120 seconds is a way to add a buffer or grace period before the token actually expires.
        memoryCache.Set("AuthToken", tokenResult, TimeSpan.FromSeconds(tokenResult.SecondsUntilExpiration - 120));
        return tokenResult;
    }
}