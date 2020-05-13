using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CadenzApp.BusinessLogic;
using CadenzApp.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadenzApp.Controllers
{
    public class StudentsController : Controller
    {
        protected readonly StudentsBusinessLogic BsLogic = new StudentsBusinessLogic();
        protected readonly TasksBusinessLogic TaskBsLogic = new TasksBusinessLogic();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult InsertStudent(MasterStudent Student)
        {
            return Json(BsLogic.InsertStudent(Student));
        }

        public JsonResult GetStudentList()
        {
            return Json(BsLogic.GetStudent());
        }

        public JsonResult GetStudent(int ID)
        {
            return Json(BsLogic.GetStudent(ID));
        }

        public JsonResult DeleteStudent(int ID)
        {
            return Json(BsLogic.DeleteStudent(ID));
        }

        #region Tasks
        public JsonResult InsertTask([FromBody] JObject data)
        {

            MasterTask Task = data.ToObject<MasterTask>();
            return Json(TaskBsLogic.InsertTask(Task));
        }
        
        //[HttpPost]
        //public async Task<JsonResult> InsertTask()
        //{
        //    using var reader = new StreamReader(HttpContext.Request.Body);

        //    // You shouldn't need this line anymore.
        //    // reader.BaseStream.Seek(0, SeekOrigin.Begin);

        //    // You now have the body string raw
        //    var body = await reader.ReadToEndAsync();

        //    // As well as a bound model
        //    MasterTask Task = JsonConvert.DeserializeObject<MasterTask>(body);
        //    Console.WriteLine("test");
        //    var json = Json(TaskBsLogic.InsertTask(Task));
        //    return json;
        //}

        public JsonResult GetTask(int StudentID, int ID)
        {
            return Json(TaskBsLogic.GetTask(StudentID, ID));
        }

        public JsonResult GetTaskList(int StudentID)
        {
            return Json(TaskBsLogic.GetTask(StudentID, null));
        }

        public JsonResult DeleteTask(int ID)
        {
            return Json(TaskBsLogic.DeleteTask(ID));
        }
        #endregion
    }
}
