using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/*using Microsoft.AspNetCore.Session;*/
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CadenzApp.Controllers
{
    [Authorize]
    public class BaseViewController : Controller
    {

        public BaseViewController()
        {
            /*ViewBag.username = HttpContext.Session.GetString("Username") ?? "Username";
            ViewBag.email = HttpContext.Session.GetString("Email") ?? "user@email.com";
            ViewBag.role = HttpContext.Session.GetString("Role") ?? "T";
            ViewBag.picture = HttpContext.Session.GetString("Picture") ?? "placeholder.png";*/

            /* ViewBag.username = identity.Claims.Where(c => c.Type == ClaimTypes.Name).ToString() ?? "Username";
             ViewBag.email = identity.Claims.Where(c => c.Type == ClaimTypes.Email).ToString() ?? "user@email.com";
             ViewBag.role = identity.Claims.Where(c => c.Type == ClaimTypes.Role).ToString() ?? "T";
             ViewBag.picture = identity.Claims.Where(c => c.Type == "Picture").ToString() ?? "placeholder.png";*/
        }
}
}