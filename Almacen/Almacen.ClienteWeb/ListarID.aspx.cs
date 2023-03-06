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
   
    public partial class ListarID : System.Web.UI.Page
    {
        IProducto Prod;
        public ListarID()
        {
            Prod = new ProductoDAL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Text = "Buscar";
        }
        protected void MuestraToast()
        {
            String csname1 = "Toast";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            StringBuilder CadenaToast = new StringBuilder();

            CadenaToast.Append("<script type=text/javascript>");
            CadenaToast.Append("$(document).ready(function(){");
            CadenaToast.Append("$('.toast').toast('show')");
            CadenaToast.Append("});");
            CadenaToast.Append("</script>");
            cs.RegisterStartupScript(cstype, csname1, CadenaToast.ToString());
        }

        public void Mensaje(string notificacion)
        {
            string script = "document.getElementById(" + "'msjnotif'" + ").innerHTML =" + notificacion + ";";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Notificacion", script, true);

        }


        protected async void Button1_Click(object sender, EventArgs e)
        {
            int Idprod;
            Producto producto = new Producto();
            try
            {
                Idprod = Convert.ToInt16(TextBox1.Text);
                if (Idprod < 0) throw new Exception();
                producto = await Prod.ObtenerProducto(Idprod);
                if(producto != null)
                {
                    Label1.Text = producto.Nombre;
                    Label2.Text = producto.Presentacion;
                    Label3.Text = producto.CostoUnitario.ToString();
                    Label4.Text = producto.PMayoreo.ToString();
                    Label5.Text = producto.PMenudeo.ToString();
                }
                else
                {
                    Mensaje("'No se encontraron coincidencias'");
                    MuestraToast();
                }
            }
            catch(FormatException)
            {
                Mensaje("'Capture Ids válidos'");
                MuestraToast();
            }
            catch (Exception)
            {
                Mensaje("'Capture Ids positivos'");
                MuestraToast();
            }
        }
    }
}