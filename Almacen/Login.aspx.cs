using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Almacen
{
    public partial class Login : System.Web.UI.Page
    {
        string strRedirect;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bool permitido;
                if (User.Identity.IsAuthenticated)
                {
                    strRedirect = Request.QueryString["ReturnUrl"];
                    permitido = UrlAuthorizationModule.CheckUrlAccessForPrincipal(strRedirect, HttpContext.Current.User, "Get");
                    if (!permitido)
                    {
                        Response.Redirect("~/Error_401.aspx");
                    }
                }
            }
        }

        protected void Iniciar_Sesion_Click(object sender, EventArgs e)
        {
            //buscamos al usuario que se registroen la base de datos,
            //mediante el metodo "Find"

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Find(UserName.Text, Password.Text);

            //Si el usuario se encuentra en la base de datos es porque ya registro una cuenta
            if (user != null)
            {
                strRedirect = Request.QueryString["ReturnUrl"];//Se obtiene la página solicitada por el usuario
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                //Creamos la sesión el usuario
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                //Se redirige a la página solicitada
                strRedirect = "~" + strRedirect;
                Response.Redirect(this.ResolveClientUrl(strRedirect));
            }
            else
            {
                StatusText.Text = "Invalido nombre de usuario o password.";
                LoginStatus.Visible = true;
            }
        }
    }
}