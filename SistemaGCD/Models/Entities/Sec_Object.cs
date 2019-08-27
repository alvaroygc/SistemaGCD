using System;

namespace SistemaGCD.Models.Entities
{
    public class Sec_Object
    {
        public int Id { get; set; }
        public int Id_Object_Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created_On { get; set; }
        public string Sec_Name { get; set; }
    }
}
