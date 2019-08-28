using System;

namespace SistemaGCD.Models.Entities
{
    public class Role_Detail
    {
        public int Id_Role { get; set; }
        public string Role_Name { get; set; }
        public int Id_Allowed_Action { get; set; }
        public string Allowed_Action_Name { get; set; }
        public int Id_Sec_Object { get; set; }
        public string Sec_Object_Name { get; set; }
        public DateTime Created_On { get; set; }
    }
}
