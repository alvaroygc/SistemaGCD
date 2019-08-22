using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Models.DataAccess
{
    public class Object_TypeDA
    {
        public readonly AppDB db;
        private StoreProcedureNames.Object_Type querys = new StoreProcedureNames.Object_Type();

        public Object_TypeDA (AppDB db)
        {
            this.db = db;
        }

        public List<Object_Type> getAll()
        {
            db.Connection.Open();
            var object_type = db.Connection.Query<Object_Type>(StoreProcedureNames.Object_Type.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return object_type.ToList();
        }

        public List<Object_Type> GetById(int id)
        {
            db.Connection.Open();
            var object_type = db.Connection.Query<Object_Type>(StoreProcedureNames.Object_Type.getById, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return object_type.ToList();
        }
        
        public int create (Object_Type object_Type)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Object_Type.Create, new { Name = object_Type.Name, Description = object_Type.Description }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int update (Object_Type object_Type)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Object_Type.Update, new { Id=object_Type.id, Name = object_Type.Name, Description = object_Type.Description }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int delete (Object_Type object_Type)
        {
            db.Connection.Open();
            var result = db.Connection.Execute(StoreProcedureNames.Object_Type.Delete, new { Id = object_Type.id }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }
    }
}
