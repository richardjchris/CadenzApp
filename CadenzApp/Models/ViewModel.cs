using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadenzApp.Models
{
    public class SelectItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Picture { get; set; }
    }
}
