using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Models.DataAccess
{
    public class UsersDA
    {
        public readonly AppDB db;
        private StoreProcedureNames.Users querys = new StoreProcedureNames.Users();

        public UsersDA(AppDB db)
        {
            this.db = db;
        }

        public List<Users> getAll()
        {
            db.Connection.Open();
            var user = db.Connection.Query<Users>(StoreProcedureNames.Users.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return user.ToList();
        }

        public List<Users> getById(int id)
        {
            db.Connection.Open();
            var user = db.Connection.Query<Users>(StoreProcedureNames.Users.getById, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return user.ToList();
        }

        public int create(Users users)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Users.Create, new {Id_Company=users.Id_Company, Name = users.Name, Email = users.Email, Description = users.Description, Pass = users.Pass}, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int update(Users users)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Users.Update, new { Id = users.Id, Name = users.Name, Email = users.Email, Description = users.Description, Pass = users.Pass }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int delete(Users users)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Users.Delete, new { Id = users.Id }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }
    }
}
