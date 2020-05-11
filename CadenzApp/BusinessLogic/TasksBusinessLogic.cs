using System;
using System.Web;
using System.Data.SqlClient;
using CadenzApp.Models;
//using CadenzApp.Models.EDMX;

namespace CadenzApp.BusinessLogic
{
	public class TasksBusinessLogic
	{
		public string InsertTask(string Task)
		{
			return "Success";
		}

		public string GetTask(int ID)
		{
			return "Task";
		}

		public string DeleteTask(string Task)
		{
			return "Success";
		}
	}
}