using System;
using System.Collections.Generic;

namespace CadenzApp.Models.DB
{
    public partial class MasterTask
    {
        public int Id { get; set; }
        public int? TutorId { get; set; }
        public int? StudentId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? StatusId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
