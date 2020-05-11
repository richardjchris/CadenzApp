using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadenzApp.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadenzApp.Controllers
{
    public class StudentsController : Controller
    {
        protected readonly StudentsBusinessLogic BsLogic = new StudentsBusinessLogic();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult InsertStudent(string Student)
        {
            return Json(BsLogic.InsertStudent(Student), System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStudent(int StudentID)
        {
            return Json(BsLogic.GetStudent(StudentID), System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteStudent(int StudentID)
        {
            return Json(BsLogic.DeleteStudent(StudentID), System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
    }
}
