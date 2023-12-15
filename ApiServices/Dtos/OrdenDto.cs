using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  NikeUI.ApiServices.Dtos
{
    public class OrdenDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CantidadProductos { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}