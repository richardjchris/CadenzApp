using System;
using System.Web;
using System.Data.SqlClient;
using e_Tracker.Models;
using e_Tracker.Models.EDMX;

namespace CadenzApp.BusinessLogic
{
	public class StudentsBusinessLogic
	{
		public string InsertStudent(string Student)
		{
			return "Success";
		}

		public string GetStudent(int ID)
		{
			return "Student";
		}

		public string DeleteStudent(string Student)
		{
			return "Success";
		}
	}
}