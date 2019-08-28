using System;

namespace SistemaGCD.Models.Entities
{
    public class Suscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number_Case { get; set; }
        public DateTime Created_On { get; set; }
    }
}
