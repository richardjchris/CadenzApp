using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using CadenzApp.Controllers.Helper;
using CadenzApp.Models;
using CadenzApp.Models.DB;

namespace CadenzApp.Helper
{
    public class BaseBusinessLogic
    {
        protected CadenzAppContext DB = new CadenzAppContext();
        protected readonly FormHelper Forms = new FormHelper();
        protected string Username { get { return Forms.Username; } }
    }
}
