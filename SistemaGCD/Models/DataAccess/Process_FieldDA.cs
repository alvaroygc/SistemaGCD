using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Models.DataAccess
{
    public class Process_FieldDA
    {
        public readonly AppDB db;
        private StoreProcedureNames.Process_Field querys = new StoreProcedureNames.Process_Field();

        public Process_FieldDA(AppDB db)
        {
            this.db = db;
        }

        public List<Process_Field> getAll()
        {
            db.Connection.Open();
            var process_field = db.Connection.Query<Process_Field>(StoreProcedureNames.Process_Field.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return process_field.ToList();
        }

        public List<Process_Field> getById(int id)
        {
            db.Connection.Open();
            var process_field = db.Connection.Query<Process_Field>(StoreProcedureNames.Process_Field.getById, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return process_field.ToList();
        }

        public int create(Process_Field process_Field)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Process_Field.Create, new { Id_Process=process_Field.Id_Process, Name = process_Field.Name, Archive = process_Field.Archive, Id_Data_Type = process_Field.Id_Data_Type }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int update(Process_Field process_Field)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Process_Field.Update, new { Id = process_Field.Id, Id_Process = process_Field.Id_Process, Name = process_Field.Name, Archive = process_Field.Archive, Id_Data_Type = process_Field.Id_Data_Type }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int delete(Process_Field process_Field)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Process_Field.Delete, new { Id = process_Field.Id }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }
    }
}
