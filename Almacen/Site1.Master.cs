using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Almacen
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            var athenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            athenticationManager.SignOut();
            Response.Redirect("~/Index.aspx");
        }
    }
}