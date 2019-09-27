using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SistemaGCD.Models.DataAccess;
using SistemaGCD.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SistemaGCD.Security
{
    public class LogFilter : IActionFilter
    {
        public string objectName { get; set; }
        public string actionName { get; set; }

        private IServiceProvider Provider { get; }


        public LogFilter(IServiceProvider provider)
        {
            Provider = provider;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Method == System.Net.WebRequestMethods.Http.Get)
            {
                if (filterContext.HttpContext.Request.Headers["loggedUser"] == "null")
                {

                    Audit_Logs audit_Logs = new Audit_Logs
                    {

                        Id_User = 0,
                        Action = filterContext.HttpContext.Request.Path,
                        Param = "Query=" + filterContext.HttpContext.Request.QueryString
                    };

                    AppDB db = Provider.GetRequiredService<AppDB>();
                    Audit_LogsDA audit_LogsDA = new Audit_LogsDA(db);
                    var res = audit_LogsDA.create(audit_Logs);

                }

                else {

                    Audit_Logs audit_Logs = new Audit_Logs
                    {

                        Id_User = Int32.Parse(filterContext.HttpContext.Request.Headers["loggedUser"]),
                        Action = filterContext.HttpContext.Request.Path,
                        Param = "Query=" + filterContext.HttpContext.Request.QueryString
                    };

                    AppDB db = Provider.GetRequiredService<AppDB>();
                    Audit_LogsDA audit_LogsDA = new Audit_LogsDA(db);
                    var res = audit_LogsDA.create(audit_Logs);

                }



                    

                // our code before action executes
            }

            if (filterContext.HttpContext.Request.Method == System.Net.WebRequestMethods.Http.Post)
            {

                if (filterContext.HttpContext.Request.Headers["loggedUser"] == "null") {

                    Audit_Logs audit_Log = new Audit_Logs
                    {
                        Id_User = 0,
                        Action = filterContext.HttpContext.Request.Path,
                        Param = JsonConvert.SerializeObject(filterContext.ActionArguments)
                    };

                    AppDB db = Provider.GetRequiredService<AppDB>();
                    Audit_LogsDA audit_LogsDA = new Audit_LogsDA(db);
                    var res = audit_LogsDA.create(audit_Log);
                }

                else {
                    if (JsonConvert.SerializeObject(filterContext.ActionArguments).ToString() == "null")
                    {
                        Audit_Logs audit_Log = new Audit_Logs
                        {
                            Id_User = Int32.Parse(filterContext.HttpContext.Request.Headers["loggedUser"]),
                            Action = filterContext.HttpContext.Request.Path,

                            Param = "Vacio"
                        };

                        AppDB db = Provider.GetRequiredService<AppDB>();
                        Audit_LogsDA audit_LogsDA = new Audit_LogsDA(db);
                        var res = audit_LogsDA.create(audit_Log);
                    }
                    else {

                        Audit_Logs audit_Log = new Audit_Logs
                        {
                            Id_User = Int32.Parse(filterContext.HttpContext.Request.Headers["loggedUser"]),
                            Action = filterContext.HttpContext.Request.Path,

                            Param = JsonConvert.SerializeObject(filterContext.ActionArguments).ToString()
                        };

                        AppDB db = Provider.GetRequiredService<AppDB>();
                        Audit_LogsDA audit_LogsDA = new Audit_LogsDA(db);
                        var res = audit_LogsDA.create(audit_Log);
                    }


                   

                }

             

            }

             

               


        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

            // our code after action executes
        }
    }
}
