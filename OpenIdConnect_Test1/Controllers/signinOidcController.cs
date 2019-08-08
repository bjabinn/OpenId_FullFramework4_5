using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenIdConnect_Test1.Controllers
{
    [RoutePrefix("signin-oidc")]
    public class signinOidcController : Controller
    {        
        [HttpGet()]
        public void Index(string code, string state)
        {
            Console.WriteLine("");
            //return View();
        }
    }
}