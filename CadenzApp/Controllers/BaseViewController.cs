using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CadenzApp.Controllers
{
    public class BaseViewController : Controller
    {

        public BaseViewController()
        {
            //ViewBag.UserID = AppGlobal.GetAuth("uid");
            //ViewBag.Parent = GetParent();
            //ViewBag.ParentID = GetParentID();
            //ViewBag.Notification = GetNotification();C:\Users\richj\OneDrive\Documents\@Work\e-Tracker System\Reference FIle\MARS\MARVEL\Controllers\BaseController.cs
            //userLogin = Int32.Parse(((System.Security.Claims.ClaimsPrincipal)User).Claims.Where(c => c.Type == "EmployeeID").Select(c => c.Value).DefaultIfEmpty("").FirstOrDefault());
        }
    }
}