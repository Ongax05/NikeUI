using System.Net.Http.Headers;
using System.Net.Http.Json;
using NikeUI.ApiServices.Dtos;
using Microsoft.AspNetCore.Components.Authorization;
using NikeUI.ApiServices.Interfaces;

namespace NikeUI.ApiServices.Services
{
    public class OrdenProductoService(
        HttpClient httpClient,
        AuthenticationStateProvider AuthenticationProvider
    ) : IOrdenProductoService
    {
        private readonly AuthenticationStateProvider AuthenticationProvider =
            (AuthenticationService)AuthenticationProvider;
        private readonly HttpClient _httpClient = httpClient;

        public async Task<IEnumerable<OrdenProductoDto>> GetOrdenProductos()
        {
            var UserData = await AuthenticationProvider.GetAuthenticationStateAsync();
            var token = UserData.User.FindFirst("UserToken").Value;

            var request = new HttpRequestMessage(HttpMethod.Get, "api/OrdenProducto");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<OrdenProductoDto>>();
            }

            throw new Exception("Error retrieving data");
        }

        public async Task<bool> PostOrdenProducto(OrdenProductoDto OrdenProductoDto)
        {
            var UserData = await AuthenticationProvider.GetAuthenticationStateAsync();
            var token = UserData.User.FindFirst("UserToken").Value;

            var request = new HttpRequestMessage(HttpMethod.Post, "api/OrdenProducto")
            {
                Content = JsonContent.Create(OrdenProductoDto)
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
    }
}
