using System.Net.Http.Headers;
using System.Net.Http.Json;
using NikeUI.ApiServices.Dtos;
using Microsoft.AspNetCore.Components.Authorization;
using NikeUI.ApiServices.Interfaces;

namespace NikeUI.ApiServices.Services
{
    public class OrdenService(
        HttpClient httpClient,
        AuthenticationStateProvider AuthenticationProvider
    ) : IOrdenService
    {
        private readonly AuthenticationStateProvider AuthenticationProvider =
            (AuthenticationService)AuthenticationProvider;
        private readonly HttpClient _httpClient = httpClient;

        public async Task<IEnumerable<OrdenDto>> GetOrdenes()
        {
             var UserData = await AuthenticationProvider.GetAuthenticationStateAsync();
            var token = UserData.User.FindFirst("UserToken").Value;

            var request = new HttpRequestMessage(HttpMethod.Get, "api/Orden");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<OrdenDto>>();
            }

            throw new Exception("Error retrieving data");
        }

        public async Task<bool> PostOrden(OrdenDto OrdenDto)
        {
              var UserData = await AuthenticationProvider.GetAuthenticationStateAsync();
            var token = UserData.User.FindFirst("UserToken").Value;

            var request = new HttpRequestMessage(HttpMethod.Post, "api/Orden")
            {
                Content = JsonContent.Create(OrdenDto)
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
    }
}
