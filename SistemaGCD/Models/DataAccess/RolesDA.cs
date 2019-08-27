using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Models.DataAccess
{
    public class RolesDA
    {
        public readonly AppDB db;
        private StoreProcedureNames.Roles querys = new StoreProcedureNames.Roles();

        public RolesDA(AppDB db)
        {
            this.db = db;
        }

        public List<Roles> getAll()
        {
            db.Connection.Open();
            var roles = db.Connection.Query<Roles>(StoreProcedureNames.Roles.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return roles.ToList();
        }

        public List<Roles> getById(int id)
        {
            db.Connection.Open();
            var roles = db.Connection.Query<Roles>(StoreProcedureNames.Roles.getById, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return roles.ToList();
        }

        public int create(Roles roles)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Roles.Create, new { Name = roles.Name, Description = roles.Description }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int update(Roles roles)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Roles.Update, new { Id = roles.Id, Name = roles.Name, Description = roles.Description }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int delete(Roles roles)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Roles.Delete, new { Id = roles.Id }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }
    }
}
