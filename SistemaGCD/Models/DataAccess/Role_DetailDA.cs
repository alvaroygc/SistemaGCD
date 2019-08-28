using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Models.DataAccess
{
    public class Role_DetailDA
    {
        public readonly AppDB db;
        private StoreProcedureNames.Role_Detail querys = new StoreProcedureNames.Role_Detail();

        public Role_DetailDA(AppDB db)
        {
            this.db = db;
        }

        public List<Role_Detail> getAll()
        {
            db.Connection.Open();
            var role_detail = db.Connection.Query<Role_Detail>(StoreProcedureNames.Role_Detail.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return role_detail.ToList();
        }

        public List<Role_Detail> GetById(int id)
        {
            db.Connection.Open();
            var role_detail = db.Connection.Query<Role_Detail>(StoreProcedureNames.Role_Detail.getById, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return role_detail.ToList();
        }

        public int create(Role_Detail role_Detail)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Role_Detail.Create, new { Id_Role = role_Detail.Id_Role, Id_Allowed_Action=role_Detail.Id_Allowed_Action, Id_Sec_Object=role_Detail.Id_Sec_Object   }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int update(Role_Detail role_Detail)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Role_Detail.Update, new { Id_Role = role_Detail.Id_Role, Id_Allowed_Action = role_Detail.Id_Allowed_Action, Id_Sec_Object = role_Detail.Id_Sec_Object }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int delete(Role_Detail role_Detail)
        {
            db.Connection.Open();
            var result = db.Connection.Execute(StoreProcedureNames.Role_Detail.Delete, new { Id_Role = role_Detail.Id_Role, Id_Allowed_Action = role_Detail.Id_Allowed_Action, Id_Sec_Object = role_Detail.Id_Sec_Object }, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }
    }
}
