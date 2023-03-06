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
using System.Threading.Tasks;


namespace Almacen.Almacen.ClienteWeb
{
    public partial class Listar : System.Web.UI.Page
    {
        IProducto Prod;
        public Listar()
        {
            Prod = new ProductoDAL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MuestraToast()
        {
            String csname1 = "Toast";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            StringBuilder CadenaToast = new StringBuilder();

            CadenaToast.Append("<script type=text/javascript>");
            CadenaToast.Append("$(document).ready(function(){");
            CadenaToast.Append("});");
            CadenaToast.Append("<>/script");
            cs.RegisterStartupScript(cstype, csname1, CadenaToast.ToString());

        }
        protected void Mensaje(string notificacion)
        {
            string script = "document.getElementById(" + "'msjnotif'" + ").innerHTML =" + notificacion + ";";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Notificacion", script, true);

        }
        public async Task<List<Producto>> ObtenerProductos()
        {
            List<Producto> ListProductos = new List<Producto>();
            ListProductos = await Prod.ObtenerProductos();
            if (ListProductos == null)
            {
                Mensaje("'No se devolvieron registros'");
                MuestraToast();
                return null;
            }
            return ListProductos;
        }
    }
}