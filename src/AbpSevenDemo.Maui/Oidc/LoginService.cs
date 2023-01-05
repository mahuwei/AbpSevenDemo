using System.IdentityModel.Tokens.Jwt;
using CommunityToolkit.Mvvm.Messaging;
using IdentityModel.OidcClient;
using AbpSevenDemo.Maui.Messages;
using AbpSevenDemo.Maui.Storage;
using Volo.Abp.DependencyInjection;

namespace AbpSevenDemo.Maui.Oidc;

public class LoginService : ILoginService, ITransientDependency
{
    private readonly OidcClient _oidcClient;
    private readonly IStorage _storage;

    public LoginService(OidcClient oidcClient, IStorage storage)
    {
        _oidcClient = oidcClient;
        _storage = storage;
    }

    public async Task<LoginResult> LoginAsync()
    {
        var loginResult = await _oidcClient.LoginAsync(new LoginRequest());

        if (!loginResult.IsError)
        {
            await SetTokenCacheAsync(loginResult.AccessToken, loginResult.RefreshToken);
            WeakReferenceMessenger.Default.Send(new LoginMessage());
        }

        return loginResult;
    }

    public async Task<LogoutResult> LogoutAsync()
    {
        var logoutResult = await _oidcClient.LogoutAsync();
        if (!logoutResult.IsError)
        {
            await ClearTokenCacheAsync();
            WeakReferenceMessenger.Default.Send(new LogoutMessage());
        }

        return logoutResult;
    }

    public async Task<string> GetAccessTokenAsync()
    {
        var token = await _storage.GetAsync(AbpSevenDemoConsts.OidcConsts.AccessTokenKeyName);

        if (!token.IsNullOrEmpty())
        {
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            if (jwtToken.ValidTo <= DateTime.UtcNow)
            {
                var refreshToken = await _storage.GetAsync(AbpSevenDemoConsts.OidcConsts.RefreshTokenKeyName);
                if (!refreshToken.IsNullOrEmpty())
                {
                    var refreshResult = await _oidcClient.RefreshTokenAsync(refreshToken);
                    await SetTokenCacheAsync(refreshResult.AccessToken, refreshResult.RefreshToken);

                    return refreshResult.AccessToken;
                }

                await ClearTokenCacheAsync();
                WeakReferenceMessenger.Default.Send(new LogoutMessage());
            }
        }

        return token;
    }

    private async Task SetTokenCacheAsync(string accessToken, string refreshToken)
    {
        await _storage.SetAsync(AbpSevenDemoConsts.OidcConsts.AccessTokenKeyName, accessToken);
        await _storage.SetAsync(AbpSevenDemoConsts.OidcConsts.RefreshTokenKeyName, refreshToken);
    }

    private async Task ClearTokenCacheAsync()
    {
        await _storage.RemoveAsync(AbpSevenDemoConsts.OidcConsts.AccessTokenKeyName);
        await _storage.RemoveAsync(AbpSevenDemoConsts.OidcConsts.RefreshTokenKeyName);
    }
}