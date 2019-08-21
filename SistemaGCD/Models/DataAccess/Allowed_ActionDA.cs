﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Models.DataAccess
{
    public class Allowed_ActionDA
    {
        public readonly AppDB db;
        private StoreProcedureNames.Allowed_Action querys = new StoreProcedureNames.Allowed_Action();

        public Allowed_ActionDA (AppDB db)
        {
            this.db = db;
        }
        
        public List<Allowed_Action> getAll()
        {
            db.Connection.Open();
            var allowed_action = db.Connection.Query<Allowed_Action>(StoreProcedureNames.Allowed_Action.selectAll, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return allowed_action.ToList();
        }

        public List<Allowed_Action> get (int Id)
        {
            db.Connection.Open();
            var allowed_action = db.Connection.Query<Allowed_Action>(StoreProcedureNames.Allowed_Action.getById, commandType: CommandType.StoredProcedure); 
            db.Connection.Close();
            return allowed_action.ToList();
        }

        public int create (Allowed_Action allowed_Action)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Allowed_Action.Create, allowed_Action, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;            
        }

        public int update (Allowed_Action allowed_Action)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Allowed_Action.Update, allowed_Action,  commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }

        public int delete (Allowed_Action allowed_Action)
        {
            db.Connection.Open();
            int result = db.Connection.Execute(StoreProcedureNames.Allowed_Action.Delete, allowed_Action, commandType: CommandType.StoredProcedure);
            db.Connection.Close();
            return result;
        }
    }
}
