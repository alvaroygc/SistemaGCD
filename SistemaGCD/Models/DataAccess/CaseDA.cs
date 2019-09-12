using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Models.DataAccess
{
    public class CaseDA
    {
        public readonly AppDB db;
        private StoreProcedureNames.Case querys = new StoreProcedureNames.Case();

        public CaseDA(AppDB db)
        {
            this.db = db;
        }

        public List<Case> getAll()
        {
            db.Connection.Open();
            var cases = db.Connection.Query<Case>(StoreProcedureNames.Case.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return cases.ToList();
        }

        public List<Case> getById(int id)
        {
            db.Connection.Open();
            var cases = db.Connection.Query<Case>(StoreProcedureNames.Case.getById, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return cases.ToList();
        }

        public int create(Case cases)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Case.Create, new { Id_Company= cases.Id_Company, Name = cases.Name, Description = cases.Description, Created_By=cases.Created_By, Id_Status=cases.Id_Status }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int update(Case cases)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Case.Update, new { Id = cases.Id, Id_Company = cases.Id_Company, Name = cases.Name, Description = cases.Description, Created_By = cases.Created_By, Id_Status = cases.Id_Status }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int delete(Case cases)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Case.Delete, new { Id = cases.Id }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }
    }
}
