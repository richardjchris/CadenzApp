using System;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using CadenzApp.Helper;
using CadenzApp.Models;
using CadenzApp.Models.DB;

namespace CadenzApp.BusinessLogic
{
    public class ComboboxBusinessLogic : BaseBusinessLogic
    {
        
        public List<ViewMasterInstrument> GetInstrumentsOption()
        {
            try
            {
                var data = DB.ViewMasterInstrument.Where(o => o.IsActive.Equals(true)).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
    }
}