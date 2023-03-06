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
    public partial class Ventas : System.Web.UI.Page
    {
        IVentas Prod;
        Producto producto;
        int Idprod;
        Venta venta;
        IAgregar Agregarventa;
        static double total;

        public Ventas()
        {
            Prod = new VentasDAL();
            producto = new Producto();
            Agregarventa = new AgregarDAL();
            venta = new Venta();
        }
        protected void MuestraToast()
        {
            string csname1 = "Toast";
            Type cstype = GetType();
            ClientScriptManager cs = Page.ClientScript;
            StringBuilder CadenaToast = new StringBuilder();

            CadenaToast.Append("<script type=text/javascript>");
            CadenaToast.Append("$(document).ready(function(){");
            CadenaToast.Append(" $('.toast').toast('show');");
            CadenaToast.Append("});");
            CadenaToast.Append("</script>");
            cs.RegisterStartupScript(cstype, csname1, CadenaToast.ToString());
        }
        protected void Mensaje(string notificacion)
        {
            string script = "document.getElementById(" + "'msjnotif'" + ").innerHTML =" + notificacion + ";";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Notificacion", script, true);
        }

        protected void Modal(string nommodal)
        {
            String csname1 = "VentanaModal";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            StringBuilder cstext1 = new StringBuilder();

            cstext1.Append("<script type=text/javascript>");
            cstext1.Append("$(document).ready(function(){");
            cstext1.Append("$(" + nommodal + ").modal('show');");
            cstext1.Append("});");
            cstext1.Append("</script>");
            cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
        }
        protected async void Page_Load(object sender, EventArgs e)
        {
            List<string> ProdId = new List<string>();
            Label2.Text = "Cantidad: ";
            Button2.Text = "Registrar_Venta";
            Button2.Enabled = false;
            if (!IsPostBack)
            {
                RadioButton1.GroupName = "Radio";
                RadioButton2.GroupName = "Radio";
                DropDownList1.AutoPostBack = true;
                Button1.Text = "Calcular";
                Label3.Text = "Total a Pagar: ";
                ProdId = await Prod.ObtenerProductoId();
                if (ProdId.Count > 0)
                {
                    DropDownList1.Items.Clear();
                    DropDownList1.Items.Add("Selecciona Id");
                    for(int i = 0; i < ProdId.Count; ++i)
                    {
                        DropDownList1.Items.Add(ProdId[i]);
                    }
                }
                else
                {
                    Mensaje("'No se velovieron Ids de los productos'");
                    MuestraToast();
                }
            }
        }

        protected async void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Idprod = Convert.ToInt16(DropDownList1.SelectedItem.ToString());
                if (Idprod < 0) throw new Exception();
                producto = await Prod.ObtenerProducto(Idprod);
                if (producto != null) Label1.Text = "Descripcion " + producto.Nombre + " " + producto.Presentacion;
                else
                {
                    Mensaje("'No se encontraron coincidencias'");
                    MuestraToast();

                }
            }
            catch(Exception x)
            {
                Mensaje("'" + x.Message + "'");
                MuestraToast();
            }

        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            int cantidad;
            Label3.Text = "";
            try
            {
                Idprod = Convert.ToInt16(DropDownList1.SelectedItem.ToString());
                producto = await Prod.ObtenerProducto(Idprod);
                cantidad = Convert.ToInt16(TextBox1.Text);
                if (cantidad < 0) throw new ArithmeticException();
                else
                {
                    if ((!RadioButton1.Checked) && (!RadioButton2.Checked))
                    {
                        Mensaje("'Seleccione Precio de Mayoreo o Menudeo'");
                        MuestraToast();
                    }
                    else
                    {
                        if (RadioButton1.Checked)
                        {
                            total = producto.PMayoreo = cantidad;
                            if (CheckBox1.Checked)
                            {
                                total = total - (total * 0.20);
                            }
                        }
                        if (RadioButton2.Checked)
                        {
                            total = producto.PMayoreo * cantidad;
                            if (CheckBox1.Checked)
                            {
                                total = total - (total * 0.20);
                            }
                        }
                    }
                    if (RadioButton1.Checked)
                    {
                        total = producto.PMayoreo * cantidad;
                        if (CheckBox1.Checked)
                        {
                            total = total - (total * 0.20);
                        }
                    }
                }
                Label3.Text = "Total a Pagar: " + total.ToString();
                Button2.Enabled = true;
            }
            catch (FormatException)
            {
                Mensaje("'Seleccione Id o capture cantidad'");
                MuestraToast();
            }
            catch (ArithmeticException)
            {
                Mensaje("'Cantidades positivas'");
                MuestraToast();
            }
            catch (Exception)
            {
                Mensaje("Seleccione Id del producto");
                MuestraToast();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string modal = "'#Pregunta'";
            Modal(modal); ;
        }

        protected async void Button3_Click(object sender, EventArgs e)
        {
            venta.ProductoId = Convert.ToInt16(DropDownList1.SelectedItem.ToString());
            venta.Cantidad = Convert.ToInt16(TextBox1.Text);
            venta.TotalVenta =  total;
            venta.Fecha = DateTime.Now;
            if (await Agregarventa.RegistrarVenta(venta))
            {
                Mensaje("'La Venta Se Registró Satisfactoriamente'");
                MuestraToast();
            }
            else
            {
                Mensaje("'Ocurrió un error al registrar la venta'");
                MuestraToast();
            }
        }
    }
}