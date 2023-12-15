using System.Net.Http.Headers;
using System.Net.Http.Json;
using NikeUI.ApiServices.Dtos;
using Microsoft.AspNetCore.Components.Authorization;
using NikeUI.ApiServices.Interfaces;

namespace NikeUI.ApiServices.Services
{
    public class UserService(
        HttpClient httpClient,
        AuthenticationStateProvider AuthenticationProvider
    ) : IUserService
    {
        private readonly AuthenticationStateProvider AuthenticationProvider =
            (AuthenticationService)AuthenticationProvider;
        private readonly HttpClient _httpClient = httpClient;

        public Task<bool> PostUser(RegisterDto RegisterDto)
        {
            throw new NotImplementedException();
        }
    }
}
