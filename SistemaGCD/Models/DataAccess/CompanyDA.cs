using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Models.DataAccess
{
    public class CompanyDA
    {
        public readonly AppDB db;
        private StoreProcedureNames.Company querys = new StoreProcedureNames.Company();

        public CompanyDA(AppDB db)
        {
            this.db = db;
        }

        public List<Company> getAll()
        {
            db.Connection.Open();
            var company = db.Connection.Query<Company>(StoreProcedureNames.Company.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return company.ToList();
        }

        public List<Company> getById(int id)
        {
            db.Connection.Open();
            var company = db.Connection.Query<Company>(StoreProcedureNames.Company.getById, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return company.ToList();
        }

        public int create(Company company)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Company.Create, new {Id_Suscription=company.Id_Suscription, Email=company.Email, Name=company.Name, Address=company.Address, Phone=company.Phone, Pass=company.Pass}, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int update(Company company)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Company.Update, new { Id = company.Id, Id_Suscription = company.Id_Suscription, Email = company.Email, Name = company.Name, Address = company.Address, Phone = company.Phone, Pass = company.Pass }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int delete(Company company)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Company.Delete, new { Id = company.Id }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }
    }
}
