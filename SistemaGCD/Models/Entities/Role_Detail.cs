using System;

namespace SistemaGCD.Models.Entities
{
    public class Role_Detail
    {
        public int id_Role { get; set; }
        public string Role_Name { get; set; }
        public int id_Allowed_Action { get; set; }
        public string allowed_Action_Name { get; set; }
        public int id_Sec_Object { get; set; }
        public string sec_Object_Name { get; set; }
        public DateTime Created_On { get; set; }
    }
}
