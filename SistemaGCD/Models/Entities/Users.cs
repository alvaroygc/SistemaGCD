using System;

namespace SistemaGCD.Models.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Pass { get; set; }
        public DateTime Created_On { get; set; }
    }
}
