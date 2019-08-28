using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Models.DataAccess
{
    public class SuscriptionDA
    {
        public readonly AppDB db;
        private StoreProcedureNames.Suscription querys = new StoreProcedureNames.Suscription();

        public SuscriptionDA(AppDB db)
        {
            this.db = db;
        }

        public List<Suscription> getAll()
        {
            db.Connection.Open();
            var suscription = db.Connection.Query<Suscription>(StoreProcedureNames.Suscription.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return suscription.ToList();
        }

        public List<Suscription> getById(int id)
        {
            db.Connection.Open();
            var suscription = db.Connection.Query<Suscription>(StoreProcedureNames.Suscription.getById, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return suscription.ToList();
        }

        public int create(Suscription suscription)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Suscription.Create, new { Name = suscription.Name, Description = suscription.Description, Number_Case=suscription.Number_Case }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int update(Suscription suscription)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Suscription.Update, new { Id = suscription.Id, Name = suscription.Name, Description = suscription.Description, Number_Case = suscription.Number_Case }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int delete(Suscription suscription)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Suscription.Delete, new { Id = suscription.Id }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }
    }
}
