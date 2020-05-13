﻿using System;
using System.Web;
using System.Data.SqlClient;
using CadenzApp.Models;
using CadenzApp.Models.DB;
using System.Linq;
using System.Collections.Generic;

namespace CadenzApp.BusinessLogic
{
    public class TasksBusinessLogic
    {
        CadenzAppContext DB = new CadenzAppContext();

        public string InsertTask(MasterTask Object)
        {
            string ReturnMess;

            try
            {
                //Controllers.Auth.AuthController auth = new Controllers.Auth.AuthController();
                var UpdateTrail = System.DateTime.Now;
                var Username = "Jason";

                if (Object.Id == 0)
                {
                    Object.IsActive = true;
                    Object.CreatedBy = Username;
                    Object.CreatedDate = UpdateTrail;
                    Object.ModifiedBy = Username;
                    Object.ModifiedDate = UpdateTrail;
                    DB.MasterTask.Add(Object);
                    DB.SaveChanges();
                    ReturnMess = "1";
                }
                else
                {
                    var Existing = DB.MasterTask.Where(o => o.Id.Equals(Object.Id)).FirstOrDefault();
                    Existing.StudentId = Object.StudentId;
                    Existing.TutorId = Object.TutorId;
                    Existing.StatusId = Object.StatusId;
                    Existing.Type = Object.Type;
                    Existing.Name = Object.Name;
                    Existing.Description = Object.Description;
                    Existing.DateEnd = Object.DateEnd;
                    Existing.ModifiedBy = Username;
                    Existing.ModifiedDate = UpdateTrail;
                    ReturnMess = Existing.Name + "\n" + DB.SaveChanges().ToString();
                }
                return ReturnMess;
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        public List<MasterTask> GetTask(int StudentID, int? TaskID)
        {
            try
            {
                if (TaskID == null)
                {
                    var data = DB.MasterTask.Where(o => o.StudentId.Equals(StudentID)).ToList();
                    return data;
                }
                else
                {
                    var data = DB.MasterTask.Where(o => o.StudentId.Equals(StudentID) && o.Id.Equals(TaskID)).ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        public string DeleteTask(int ID)
        {
            var UpdateTrail = System.DateTime.Now;
            var Username = "Jason";

            try
            {
                var returnMess = string.Empty;
                var entry = DB.MasterTask.Where(o => o.Id.Equals(ID)).FirstOrDefault();
                if (entry.IsActive == true)
                    entry.IsActive = false;
                else
                    entry.IsActive = true;
                entry.ModifiedBy = Username;
                entry.ModifiedDate = UpdateTrail;
                returnMess = DB.SaveChanges().ToString();
                return returnMess;
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
    }
}