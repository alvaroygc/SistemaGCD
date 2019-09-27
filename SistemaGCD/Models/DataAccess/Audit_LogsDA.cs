using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Models.DataAccess
{
    public class Audit_LogsDA
    {
        public readonly AppDB db;

        private StoreProcedureNames.Audit_Logs querys = new StoreProcedureNames.Audit_Logs();

        public Audit_LogsDA(AppDB db)
        {
            this.db = db;
        }

        public List<Audit_Logs> getAll()
        {
            db.Connection.Open();
            var audit_logs = db.Connection.Query<Audit_Logs>(StoreProcedureNames.Audit_Logs.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return audit_logs.ToList();
        }

        public int create(Audit_Logs audit_Logs)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Audit_Logs.Create, new { Id_User = audit_Logs.Id_User, Action = audit_Logs.Action, Param = audit_Logs.Param }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        
    }
}
