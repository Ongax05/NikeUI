using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NikeUI.ApiServices.Dtos;

namespace NikeUI.ApiServices.Interfaces
{
    public interface IOrdenProductoService
    {
        Task<IEnumerable<OrdenProductoDto>> GetOrdenProductos();
        Task<bool> PostOrdenProducto(OrdenProductoDto OrdenProductoDto);
    }
}