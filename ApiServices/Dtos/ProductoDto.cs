using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikeUI.ApiServices.Dtos
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public int CategoriaProductoId { get; set; }
        public string NombreProducto { get; set; }
        public byte[] Imagen { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
    }
}