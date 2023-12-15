using System.Net.Http.Headers;
using System.Net.Http.Json;
using NikeUI.ApiServices.Dtos;
using Microsoft.AspNetCore.Components.Authorization;
using NikeUI.ApiServices.Interfaces;

namespace NikeUI.ApiServices.Services
{
    public class CategoriaProductoService(
        HttpClient httpClient,
        AuthenticationStateProvider AuthenticationProvider
    ) : ICategoriaProductoService
    {
        private readonly AuthenticationStateProvider AuthenticationProvider =
            (AuthenticationService)AuthenticationProvider;
        private readonly HttpClient _httpClient = httpClient;

        public async Task<IEnumerable<CategoriaProductoDto>> GetCategoriaProductos()
        {
            var UserData = await AuthenticationProvider.GetAuthenticationStateAsync();
            var token = UserData.User.FindFirst("UserToken").Value;

            var request = new HttpRequestMessage(HttpMethod.Get, "api/CategoriaProducto");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<CategoriaProductoDto>>();
            }

            throw new Exception("Error retrieving data");
        }

        public async Task<bool> PostCategoriaProducto(CategoriaProductoDto CategoriaProductoDto)
        {
            var UserData = await AuthenticationProvider.GetAuthenticationStateAsync();
            var token = UserData.User.FindFirst("UserToken").Value;

            var request = new HttpRequestMessage(HttpMethod.Post, "api/CategoriaProducto")
            {
                Content = JsonContent.Create(CategoriaProductoDto)
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
    }
}
