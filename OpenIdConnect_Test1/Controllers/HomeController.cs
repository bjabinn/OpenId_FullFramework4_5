using Microsoft.Owin.Security.OpenIdConnect;
using System.Web;
using System.Web.Mvc;

namespace OpenIdConnect_Test1
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Me()
        {            
            return View();
        }
        
        public void Login()
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(OpenIdConnectAuthenticationDefaults.AuthenticationType);
                return;
            }
            Response.Redirect("/");
        }
    }
}