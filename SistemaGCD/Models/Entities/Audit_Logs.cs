using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGCD.Models.Entities
{
    public class Audit_Logs
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public string Action { get; set; }
        public string Param { get; set; }
        public DateTime Log_Date { get; set; }
        public string User_Names { get; set; }
    }
}
