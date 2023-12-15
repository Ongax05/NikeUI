using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikeUI.ApiServices.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoriaProductoService CategoriaProductoService { get; }
        IOrdenProductoService OrdenProductoService { get; }
        IOrdenService OrdenService { get; }
        IProductoService ProductoService { get; }
        IUserService UserService { get; }
    }
}
