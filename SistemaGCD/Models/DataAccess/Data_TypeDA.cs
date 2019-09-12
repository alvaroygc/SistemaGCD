using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;
namespace SistemaGCD.Models.DataAccess
{
    public class Data_TypeDA
    {
        public readonly AppDB db;
        private StoreProcedureNames.Data_Type querys = new StoreProcedureNames.Data_Type();

        public Data_TypeDA(AppDB db)
        {
            this.db = db;
        }

        public List<Data_Type> getAll()
        {
            db.Connection.Open();
            var data_type = db.Connection.Query<Data_Type>(StoreProcedureNames.Data_Type.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return data_type.ToList();
        }

        public List<Data_Type> getById(int id)
        {
            db.Connection.Open();
            var data_type = db.Connection.Query<Data_Type>(StoreProcedureNames.Data_Type.getById, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return data_type.ToList();
        }

        public int create(Data_Type data_Type)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Data_Type.Create, new { Name = data_Type.Name, Description = data_Type.Description }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int update(Data_Type data_Type)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Data_Type.Update, new { Id = data_Type.Id, Name = data_Type.Name, Description = data_Type.Description }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int delete(Data_Type data_Type)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Data_Type.Delete, new { Id = data_Type.Id }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }
    }
}
