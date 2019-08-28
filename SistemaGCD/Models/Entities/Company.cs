using System;

namespace SistemaGCD.Models.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public int  Id_Suscription { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Pass { get; set; }
        public DateTime Created_On { get; set; }
    }
}
