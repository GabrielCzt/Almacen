using Almacen.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;


namespace Almacen
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            string[] ArrayRole = new string[5];
            DataTable Dt = new DataTable();
            RolesUser rol =new  RolesUser();
            string id;
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    GenericIdentity myIdentity = new GenericIdentity(HttpContext.Current.User.Identity.Name);
                    var userStore = new UserStore<IdentityUser>();
                    var userManager = new UserManager<IdentityUser>(userStore);
                    id = userManager.FindByName(User.Identity.Name).Id;
                    Dt = rol.ObtenerRoles(id);
                    for (int i = 0; i < Dt.Rows.Count; ++i)
                    {
                        ArrayRole[i] = Dt.Rows[i]["ClaimValue"].ToString();

                    }
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(myIdentity, ArrayRole);

                }
            }
        }
        protected void Application_Start(object sender, EventArgs e)
        {
        }
    }
}