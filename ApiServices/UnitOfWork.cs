using Microsoft.AspNetCore.Components.Authorization;
using NikeUI.ApiServices.Interfaces;
using NikeUI.ApiServices.Services;

namespace NikeUI.ApiServices
{
    public class UnitOfWork(
        HttpClient httpClient,
        AuthenticationStateProvider AuthenticationProvider
    ) : IUnitOfWork
    {
        private readonly AuthenticationStateProvider _AuthenticationProvider =
            AuthenticationProvider;
        private readonly HttpClient _httpClient = httpClient;
        private ICategoriaProductoService _CategoriaProductoService;
        public ICategoriaProductoService CategoriaProductoService
        {
            get
            {
                _CategoriaProductoService ??= new CategoriaProductoService(_httpClient,_AuthenticationProvider);
                return _CategoriaProductoService;
            }
        }
        private IOrdenProductoService _OrdenProductoService;
        public IOrdenProductoService OrdenProductoService
        {
            get
            {
                _OrdenProductoService ??= new OrdenProductoService(_httpClient,_AuthenticationProvider);
                return _OrdenProductoService;
            }
        }
        private IOrdenService _OrdenService;
        public IOrdenService OrdenService
        {
            get
            {
                _OrdenService ??= new OrdenService(_httpClient,_AuthenticationProvider);
                return _OrdenService;
            }
        }
        private IProductoService _ProductoService;
        public IProductoService ProductoService
        {
            get
            {
                _ProductoService ??= new ProductoService(_httpClient,_AuthenticationProvider);
                return _ProductoService;
            }
        }
        private IUserService _UserService;
        public IUserService UserService
        {
            get
            {
                _UserService ??= new UserService(_httpClient,_AuthenticationProvider);
                return _UserService;
            }
        }
    }
}
