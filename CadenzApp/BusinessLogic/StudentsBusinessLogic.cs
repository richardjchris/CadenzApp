using System;
using System.Web;
using System.Data.SqlClient;
using CadenzApp.Models;
using CadenzApp.Models.DB;
using System.Linq;
using System.Collections.Generic;

namespace CadenzApp.BusinessLogic
{
	public class StudentsBusinessLogic
	{
		CadenzAppContext DB = new CadenzAppContext();

		public string InsertStudent(MasterStudent Student)
		{
			DB.MasterStudent.Add(Student);
			return "Success";
		}

		public List<MasterStudent> GetStudent()
		{
			try
			{
				return DB.MasterStudent.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception("Error : " + ex.Message);
			}
		}

		public MasterStudent GetStudent(int ID)
		{
			try
			{
				return DB.MasterStudent.Where(o => o.Id.Equals(ID)).FirstOrDefault();
	}
			catch (Exception ex)
			{
				throw new Exception("Error : " + ex.Message);
			}
		}

		public string DeleteStudent(int ID)
		{
			return "Success";
		}
	}
}