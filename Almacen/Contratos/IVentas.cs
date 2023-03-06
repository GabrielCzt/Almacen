using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almacen.Almacen.Entities;

namespace Almacen.Contratos
{
    interface IVentas
    {
        Task<Producto> ObtenerProducto(int id);
        Task<List<string>> ObtenerProductoId();
        Task<List<Venta>> ObtenerProductoFecha(DateTime fecha);
    }
}
