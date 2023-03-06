using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Almacen.Almacen.Entities;
using Almacen.Contratos;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Almacen.Almacen.DAL
{
    public class VentasDAL : IVentas
    {
        string dbconexion;
        public VentasDAL()
        {
            dbconexion = ConfigurationManager.ConnectionStrings["ConectaProductos"].ConnectionString;

        }
        public async Task<Producto> ObtenerProducto(int id)
        {
            Producto Pr = new Producto();
            using (SqlConnection con = new SqlConnection(dbconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerProductos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductoId", id);
                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Pr.Nombre = sdr["Nombre"].ToString();
                            Pr.Presentacion = sdr["Presentacion"].ToString();
                            Pr.PMayoreo = Convert.ToDouble(sdr["PMayoreo"]);
                            Pr.PMenudeo = Convert.ToDouble(sdr["PMenudeo"]);
                        }
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    con.Close();
                }
                return (Pr);
            }
        }



        public async Task<List<Venta>> ObtenerProductoFecha(DateTime fecha)
        {
            List<Venta> ListVentas = new List<Venta>();
            using (SqlConnection con = new SqlConnection(dbconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerProductoPorFecha", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaProducto", fecha);
                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            ListVentas.Add(new Venta
                            {
                                VentaId = Convert.ToInt16(sdr["VentaId"]),
                                ProductoId = Convert.ToInt16(sdr["ProductoId"]),
                                Cantidad = Convert.ToInt16(sdr["Cantidad"]),
                                TotalVenta = Convert.ToDouble(sdr["TotalVenta"]),
                                Fecha = Convert.ToDateTime(sdr["Fecha"]),

                            });
                        }
                        con.Close();
                    }
                    else
                    {
                        ListVentas = null;
                    }
                }
                catch (Exception)
                {
                    con.Close();
                }
                return (ListVentas);
            }
        }

        public async Task<List<string>> ObtenerProductoId()
        {
            List<string> ProductoId = new List<string>();
            using (SqlConnection con = new SqlConnection(dbconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerProductoId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            ProductoId.Add(sdr["ProductoId"].ToString());

                        }
                        con.Close();
                    }
                    else
                    {
                        ProductoId = null;
                    }
                }
                catch (Exception)
                {
                    con.Close();
                }
            }
            return (ProductoId);
        }
    }
}