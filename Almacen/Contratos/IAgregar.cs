using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almacen.Almacen.Entities;


namespace Almacen.Contratos
{
    interface IAgregar
    {
        Task<bool> RegistrarVenta(Venta Vnta);
    }
}
