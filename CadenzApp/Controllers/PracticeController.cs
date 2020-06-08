using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadenzApp.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using CadenzApp.Models.DB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CadenzApp.Controllers
{
    public class PracticeController : BaseViewController
    {
        protected readonly PracticeBusinessLogic BsLogic = new PracticeBusinessLogic();
        protected readonly ComboboxBusinessLogic CmbBsLogic = new ComboboxBusinessLogic();

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult InsertPracticeLog([FromBody] JObject data)
        {

            PracticeLog Log = data.ToObject<PracticeLog>();
            return Json(BsLogic.InsertPracticeLog(Log));
        }

        public JsonResult GetPracticeLogList(int StudentID)
        {
            return Json(BsLogic.GetPracticeLog(StudentID));
        }

        public JsonResult GetPracticeLog(int ID)
        {
            return Json(BsLogic.GetPracticeLog(ID));
        }

        /*public JsonResult GetPracticeHours(int StudentID, DateTime Date)
        {
            return Json(BsLogic.GetPracticeHours(Date, StudentID));
        }*/

        public JsonResult DeletePracticeLog(int StudentID, DateTime Date)
        {
            return Json(BsLogic.DeletePracticeLog(StudentID, Date));
        }

        public JsonResult GetInstrumentOptions()
        {
            return Json(CmbBsLogic.GetInstrumentsOption());
        }
    }
}