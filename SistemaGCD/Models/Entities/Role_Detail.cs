using System;

namespace SistemaGCD.Models.Entities
{
    public class Role_Detail
    {
        public int Id_Role { get; set; }
        public int Id_Allowed_Action { get; set; }
        public int Id_Sec_Object { get; set; }
        public DateTime Created_On { get; set; }
    }
}
