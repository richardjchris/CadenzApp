using System;
using System.Collections.Generic;

namespace CadenzApp.Models.DB
{
    public partial class MasterStudent
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? TutorId { get; set; }
        public int? InstrumentId { get; set; }
        public int? YearOfStudy { get; set; }
        public string PlaceOfOccupation { get; set; }
        public DateTime? JoinDate { get; set; }
        public bool? IsActiveStudent { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
