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

        public List<Login_Model> Login(string email, string pass)
        { 
            db.Connection.Open();
            var result = db.Connection.Query<Login_Model>(StoreProcedureNames.Users.Login, new { Email = email, Pass = pass }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result.ToList();
        }

        public List<Token> Token(string text)
        {
            db.Connection.Open();
            var result = db.Connection.Query<Token>(StoreProcedureNames.Users.Token_Verify , new { text=text }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result.ToList();
        }

        public int create_Token(Token token)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Users.Token, new { text =token.text, expired_dt=token.expired_dt, status=token.status, created_dt =token.created_dt, id_User = token.id_User }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int Desative_Token(Token token) {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Users.Desactive_Token, new { text = token.text }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

    }
}
