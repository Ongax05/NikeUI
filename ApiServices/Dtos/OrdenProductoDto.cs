using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  NikeUI.ApiServices.Dtos
{
    public class OrdenProductoDto
    {
        public int ProductoId { get; set; }
        public int OrdenId { get; set; }
        public int Cantidad { get; set; }
    }
}