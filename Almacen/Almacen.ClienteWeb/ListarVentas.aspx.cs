using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Almacen.Almacen.DAL;
using Almacen.Almacen.Entities;
using Almacen.Contratos;
using System.Text;

namespace Almacen.Almacen.ClienteWeb
{
    public partial class ListarVentas : System.Web.UI.Page
    {
        IVentas ListVentas;

        public ListarVentas()
        {
            ListVentas = new VentasDAL();
        }
        protected void MuestraToast()
        {
            String csname1 = "Toast";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            StringBuilder CadenaToast = new StringBuilder();

            CadenaToast.Append("<script type=text/javascript>");
            CadenaToast.Append("$(document).ready(function(){");
            CadenaToast.Append("$('.toast').toast('show');");
            CadenaToast.Append("});");
            CadenaToast.Append("</script>");
            cs.RegisterStartupScript(cstype, csname1, CadenaToast.ToString());


        }
        protected void Mensaje(string notificacion)
        {
            string script = "document.getElementById(" + "'msjnotif'" + ").innerHTML = " + notificacion + ";";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Notificacion", script, true);

        }

        protected void GeneraColumnasGrid()
        {
            BoundField column = new BoundField();
            column = new BoundField
            {
                HeaderText = "VentaId",
                DataField = "VentaId"
            };
            GridView1.Columns.Add(column);

            column = new BoundField();
            column.HeaderText = "ProductoId";
            column.DataField = "ProductoId";
            GridView1.Columns.Add(column);

            column = new BoundField();
            column.HeaderText = "Cantidad";
            column.DataField = "Cantidad";
            GridView1.Columns.Add(column);

            column = new BoundField();
            column.HeaderText = "TotalVenta";
            column.DataField = "TotalVenta";
            GridView1.Columns.Add(column);

            column = new BoundField();
            column.HeaderText = "Fecha";
            column.DataField = "Fecha";
            GridView1.Columns.Add(column);

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fecha;
            List<Venta> ListarVentas = new List<Venta>();
            fecha = Calendar1.SelectedDate;
            ListarVentas = await ListVentas.ObtenerProductoFecha(fecha);
            if(ListarVentas != null)
            {
                GeneraColumnasGrid();
                GridView1.DataSource = ListarVentas;
                GridView1.DataBind();
                GridView1.Columns.Clear();
            }
            else
            {
                Mensaje("'No hay ventas en la fecha seleccionada'");
                MuestraToast();
            }

        }
    }
}