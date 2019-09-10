using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Models.DataAccess
{
    public class Sec_ObjectsDA
    {
        public readonly AppDB db;
        private StoreProcedureNames.Sec_Object querys = new StoreProcedureNames.Sec_Object();

        public Sec_ObjectsDA(AppDB db)
        {
            this.db = db;
        }

        public List<Sec_Object> getAll()
        {
            db.Connection.Open();
            var sec_object = db.Connection.Query<Sec_Object>(StoreProcedureNames.Sec_Object.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return sec_object.ToList();
        }

        public List<Sec_Object> getById(int id)
        {
            db.Connection.Open();
            var sec_object = db.Connection.Query<Sec_Object>(StoreProcedureNames.Sec_Object.getById, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return sec_object.ToList();
        }

        public int create(Sec_Object sec_Object)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Sec_Object.Create, new {Name = sec_Object.Name, Description = sec_Object.Description}, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int update(Sec_Object sec_Object)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Sec_Object.Update, new { Id = sec_Object.Id, Name = sec_Object.Name, Description = sec_Object.Description }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int delete(Sec_Object sec_Object)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Sec_Object.Delete, new { Id = sec_Object.Id }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }
    }
}
