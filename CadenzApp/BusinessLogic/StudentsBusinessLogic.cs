using System;
using System.Web;
using System.Data.SqlClient;
using CadenzApp.Models;
using CadenzApp.Models.EDMX;

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

		public string DeleteStudent(int ID)
		{
			return "Success";
		}
	}
}