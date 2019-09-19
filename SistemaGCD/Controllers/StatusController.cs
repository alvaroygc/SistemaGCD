using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SistemaGCD.Models.DataAccess;
using SistemaGCD.Models.Entities;
using SistemaGCD.Security;

namespace SistemaGCD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StatusController : ControllerBase
    {
        private IServiceProvider provider;
        public StatusController(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Status>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            StatusDA status = new StatusDA(db);
            return status.getAll();
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<List<Status>> Get(int id)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            StatusDA status = new StatusDA(db);
            return status.getById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<object> Create(Status status)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            StatusDA statusDA = new StatusDA(db);
            var res = statusDA.create(status);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult<object> Delete(Status status)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            StatusDA statusDA = new StatusDA(db);
            var res = statusDA.delete(status);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<object> Update(Status status)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            StatusDA statusDA = new StatusDA(db);
            var res = statusDA.update(status);
            return new
            {
                result = res
            };
        }
    }
}