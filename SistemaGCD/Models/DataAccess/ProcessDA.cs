using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Models.DataAccess
{
    public class ProcessDA
    {
        public readonly AppDB db;
        private StoreProcedureNames.Process querys = new StoreProcedureNames.Process();

        public ProcessDA(AppDB db)
        {
            this.db = db;
        }

        public List<Process> getAll()
        {
            db.Connection.Open();
            var process = db.Connection.Query<Process>(StoreProcedureNames.Process.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return process.ToList();
        }

        public List<Process> getById(int id)
        {
            db.Connection.Open();
            var process = db.Connection.Query<Process>(StoreProcedureNames.Process.getById, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return process.ToList();
        }

        public int create(Process process)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Process.Create, new { Id_Case=process.Id_Case, Name=process.Name }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int update(Process process)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Process.Update, new { Id = process.Id, Id_Case = process.Id_Case, Name = process.Name }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int delete(Process process)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Process.Delete, new { Id = process.Id }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }
    }
}
