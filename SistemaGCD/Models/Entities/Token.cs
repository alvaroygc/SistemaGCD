using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGCD.Models.Entities
{
    public class Token
    {
        public int Id { get; set; }
        public string text { get; set; }
        public System.DateTime expired_dt { get; set; }
        public string status { get; set; }
        public System.DateTime created_dt { get; set; }
        public int id_User { get; set; }

        public virtual Users User { get; set; }
    }
}
