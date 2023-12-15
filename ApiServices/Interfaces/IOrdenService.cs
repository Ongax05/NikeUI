using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NikeUI.ApiServices.Dtos;

namespace NikeUI.ApiServices.Interfaces
{
    public interface IOrdenService
    {
        Task<IEnumerable<OrdenDto>> GetOrdenes();
        Task<bool> PostOrden(OrdenDto OrdenDto);
    }
}