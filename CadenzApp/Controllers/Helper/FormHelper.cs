using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CadenzApp.Controllers.Helper
{
    public class FormHelper : Controller
    {
        //UpdateTrail
        public string Username { get { return "Joseph"; } }
        public DateTime UpdateTime { get { return DateTime.Now; } }
    }
}