using System;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using CadenzApp.Helper;
using CadenzApp.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace CadenzApp.BusinessLogic
{
    public class PracticeBusinessLogic : BaseBusinessLogic
    {
        public string InsertPracticeLog(PracticeLog Object)
        {
            string ReturnMess;

            try
            {
                //Controllers.Auth.AuthController auth = new Controllers.Auth.AuthController();
                var UpdateTrail = System.DateTime.Now;
                var Existing = DB.PracticeLog.Where(o => o.StudentId.Equals(Object.StudentId) && o.Date.Equals(Object.Date)).FirstOrDefault();

                if (Existing == null)
                {
                    Object.CreatedBy = Username;
                    Object.CreatedDate = UpdateTrail;
                    Object.ModifiedBy = Username;
                    Object.ModifiedDate = UpdateTrail;
                    DB.PracticeLog.Add(Object);
                    DB.SaveChanges();
                    ReturnMess = "1";
                }
                else
                {
                    Existing.PracticeHours = Object.PracticeHours;
                    Existing.Song = Object.Song;
                    Existing.InstrumentId = Object.InstrumentId;
                    Existing.Description = Object.Description;
                    Existing.ModifiedBy = Username;
                    Existing.ModifiedDate = UpdateTrail;
                    ReturnMess = DB.SaveChanges().ToString();
                }
                return ReturnMess;
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        public List<PracticeLog> GetPracticeLog(int StudentID)
        {
            try
            {
                var data = DB.PracticeLog.Where(o => o.StudentId.Equals(StudentID)).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        /*public IQueryable<Hours> GetPracticeHours(DateTime Date, int StudentID)
        {
            var query = "SELECT * FROM GetTotalPracticeHours(" + Date + ", + " + StudentID + ");";
            var Hours = DB.Hours.FromSqlRaw(query);
            return Hours;
        }*/

        public string DeletePracticeLog(int StudentID, DateTime Date)
        {
            var UpdateTrail = System.DateTime.Now;

            try
            {
                var returnMess = string.Empty;
                DB.PracticeLog.Remove(DB.PracticeLog.Where(o => o.StudentId.Equals(StudentID) && o.Date.Equals(Date)).FirstOrDefault());
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