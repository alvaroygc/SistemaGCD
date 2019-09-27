using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SistemaGCD.Models.DataAccess;
using SistemaGCD.Models.Entities;

namespace SistemaGCD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private IServiceProvider provider;

        public AuditController(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Audit_Logs>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            Audit_LogsDA audit_LogsDA = new Audit_LogsDA(db);
            return audit_LogsDA.getAll();
        }
    }
}