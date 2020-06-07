using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using CadenzApp.Controllers.Helper;
using CadenzApp.Models;
using CadenzApp.Models.DB;

namespace CadenzApp.BusinessLogic
{
    public class IBussinessLogic
    {
        CadenzAppContext DB = new CadenzAppContext();
        FormHelper Forms = new FormHelper();
        string Username { get { return Forms.Username; } }
    }
}
