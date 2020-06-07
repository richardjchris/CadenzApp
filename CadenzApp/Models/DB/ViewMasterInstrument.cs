using System;
using System.Collections.Generic;

namespace CadenzApp.Models.DB
{
    public partial class ViewMasterInstrument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
