using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NikeUI.ApiServices.Dtos;

namespace NikeUI.ApiServices.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDto>> GetProductos();
        Task<IEnumerable<ProductoDto>> GetAbrigos();
        Task<IEnumerable<ProductoDto>> GetCamisetas();
        Task<IEnumerable<ProductoDto>> GetPantalones();
        Task<bool> PostProducto(ProductoDto ProductoDto);
    }
}