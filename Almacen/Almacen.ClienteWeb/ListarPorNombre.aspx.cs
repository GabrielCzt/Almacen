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
    public partial class ListarPorNombre : System.Web.UI.Page
    {
        IProducto ListNombre;
        public ListarPorNombre()
        {
            ListNombre = new ProductoDAL();
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
            string script = "document.getElementById("+"'msjnotif'"+").innerHTML = "+notificacion + ";";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Notificacion", script, true);

        }
        protected void GeneraColumnasGrid()
        {
            BoundField column = new BoundField();
            column = new BoundField
            {
                HeaderText = "Nombre",
                DataField = "Nombre"
            };
            GridView1.Columns.Add(column);

            column = new BoundField();
            column.HeaderText = "Presentación";
            column.DataField = "Presentacion";
            GridView1.Columns.Add(column);

            column = new BoundField();
            column.HeaderText = "PrecioMayoreo";
            column.DataField = "PMayoreo";
            GridView1.Columns.Add(column);

            column = new BoundField();
            column.HeaderText = "PrecioMenudeo";
            column.DataField = "PMenudeo";
            GridView1.Columns.Add(column);

            column = new BoundField();
            column.HeaderText = "Existencia";
            column.DataField = "Existencia";
            GridView1.Columns.Add(column);

            column = new BoundField();
            column.HeaderText = "CostoUnitario";
            column.DataField = "CostoUnitario";
            GridView1.Columns.Add(column);





        }
        protected async void Page_Load(object sender, EventArgs e)
        {
            List<string> NombreProd = new List<string>();
            if (!IsPostBack)
            {
                DropDownList1.AutoPostBack = true;
                NombreProd = await ListNombre.ObtenerNombreProducto();
                if (NombreProd.Count > 0)
                {
                    DropDownList1.Items.Clear();
                    DropDownList1.Items.Add("Selecciona Producto");
                    for(int i = 0; i < NombreProd.Count; ++i)
                    {
                        DropDownList1.Items.Add(NombreProd[i]);
                    }
                }
                else
                {
                    Mensaje("No se devolvieron nombres de los productos");
                    MuestraToast();
                }
            }
        }

        protected async void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Nombre;
            List<Producto> ListProductos = new List<Producto>();
            Nombre = DropDownList1.SelectedItem.ToString();
            ListProductos = await ListNombre.ObtenerProductoPorNombre(Nombre);
            if(ListProductos != null)
            {
                GeneraColumnasGrid();
                GridView1.DataSource = ListProductos;
                GridView1.DataBind();
                GridView1.Columns.Clear();
            }
            else
            {
                Mensaje("'No se encontraron coincidencias'");
                MuestraToast();
            }
        }
    }
}