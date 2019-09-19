using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGCD.Models.Entities
{
    public class Login_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Id_Company { get; set; }
    }
}
