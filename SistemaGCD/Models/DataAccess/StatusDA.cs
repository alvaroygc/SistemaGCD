using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Models.DataAccess
{
    public class StatusDA
    {
        public readonly AppDB db;
        private StoreProcedureNames.Status querys = new StoreProcedureNames.Status();

        public StatusDA(AppDB db)
        {
            this.db = db;
        }

        public List<Status> getAll()
        {
            db.Connection.Open();
            var status = db.Connection.Query<Status>(StoreProcedureNames.Status.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return status.ToList();
        }

        public List<Status> getById(int id)
        {
            db.Connection.Open();
            var status = db.Connection.Query<Status>(StoreProcedureNames.Status.getById, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return status.ToList();
        }

        public int create(Status status)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Status.Create, new { Name = status.Name, Description = status.Description }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int update(Status status)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Status.Update, new { Id = status.Id, Name = status.Name, Description = status.Description }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int delete(Status status)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Status.Delete, new { Id = status.Id }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }
    }
}
