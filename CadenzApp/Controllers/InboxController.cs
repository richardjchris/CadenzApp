using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CadenzApp.Controllers
{
    public class InboxController : BaseViewController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}