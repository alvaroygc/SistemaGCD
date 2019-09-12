using System;

namespace SistemaGCD.Models.Entities
{
    public class Case
    {
        public int Id { get; set; }
        public int Id_Company { get; set; }
        public string Company_Name { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Created_By { get; set; }
        public string Created_Name { get; set; }
        public DateTime Created_On { get; set; }
        public int Id_Status { get; set; }
        public string Status_Name { get; set; }
    }
}
