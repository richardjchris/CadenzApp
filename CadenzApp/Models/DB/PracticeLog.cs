using System;
using System.Collections.Generic;

namespace CadenzApp.Models.DB
{
    public partial class PracticeLog
    {
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public decimal? PracticeHours { get; set; }
        public string Song { get; set; }
        public int InstrumentID { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
