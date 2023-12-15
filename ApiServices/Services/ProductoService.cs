using System.Net.Http.Headers;
using System.Net.Http.Json;
using NikeUI.ApiServices.Dtos;
using Microsoft.AspNetCore.Components.Authorization;
using NikeUI.ApiServices.Interfaces;

namespace NikeUI.ApiServices.Services
{
    public class ProductoService(
        HttpClient httpClient,
        AuthenticationStateProvider AuthenticationProvider
    ) : IProductoService
    {
        private readonly AuthenticationStateProvider AuthenticationProvider =
            (AuthenticationService)AuthenticationProvider;
        private readonly HttpClient _httpClient = httpClient;

        public async Task<IEnumerable<ProductoDto>> GetAbrigos()
        {
            var UserData = await AuthenticationProvider.GetAuthenticationStateAsync();
            var token = UserData.User.FindFirst("UserToken").Value;

            var request = new HttpRequestMessage(HttpMethod.Get, "api/Abrigos");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProductoDto>>();
            }

            throw new Exception("Error retrieving data");
        }

        public async Task<IEnumerable<ProductoDto>> GetCamisetas()
        {
            var UserData = await AuthenticationProvider.GetAuthenticationStateAsync();
            var token = UserData.User.FindFirst("UserToken").Value;

            var request = new HttpRequestMessage(HttpMethod.Get, "api/Camisetas");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProductoDto>>();
            }

            throw new Exception("Error retrieving data");
        }

        public async Task<IEnumerable<ProductoDto>> GetPantalones()
        {
            var UserData = await AuthenticationProvider.GetAuthenticationStateAsync();
            var token = UserData.User.FindFirst("UserToken").Value;

            var request = new HttpRequestMessage(HttpMethod.Get, "api/Producto/Pantalones");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProductoDto>>();
            }

            throw new Exception("Error retrieving data");
        }

        public async Task<IEnumerable<ProductoDto>> GetProductos()
        {
            var UserData = await AuthenticationProvider.GetAuthenticationStateAsync();
            var token = UserData.User.FindFirst("UserToken").Value;

            var request = new HttpRequestMessage(HttpMethod.Get, "api/Producto");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProductoDto>>();
            }

            throw new Exception("Error retrieving data");
        }

        public async Task<bool> PostProducto(ProductoDto ProductoDto)
        {
            var UserData = await AuthenticationProvider.GetAuthenticationStateAsync();
            var token = UserData.User.FindFirst("UserToken").Value;

            var request = new HttpRequestMessage(HttpMethod.Post, "api/Producto")
            {
                Content = JsonContent.Create(ProductoDto)
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
    }
}
