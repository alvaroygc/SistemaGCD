using System;

namespace SistemaGCD.Models.Entities
{
    public class Process
    {
        public int Id { get; set; }
        public int Id_Case { get; set; }
        public string Case_Name { get; set; }
        public string Name { get; set; }
        public int Correlative { get; set; }
    }
}
