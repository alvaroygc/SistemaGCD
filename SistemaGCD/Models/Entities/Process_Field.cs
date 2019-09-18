using System;

namespace SistemaGCD.Models.Entities
{
    public class Process_Field
    {
        public int Id { get; set; }
        public int Id_Process { get; set; }
        public string Process_Name { get; set; }
        public string Name { get; set; }
        public string Archive { get; set; }
        public int Id_Data_Type { get; set; }
        public string Data_Type_Name { get; set; }
    }
}
