using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NikeUI.ApiServices.Dtos;

namespace NikeUI.ApiServices.Interfaces
{
    public interface ICategoriaProductoService
    {
        Task<IEnumerable<CategoriaProductoDto>> GetCategoriaProductos();
        Task<bool> PostCategoriaProducto(CategoriaProductoDto CategoriaProductoDto);
    }
}