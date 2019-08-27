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
    public class Allowed_ActionController : ControllerBase
    {
        private IServiceProvider provider;

        public Allowed_ActionController(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }
        
        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Allowed_Action>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            Allowed_ActionDA allowed_Action = new Allowed_ActionDA(db);
            return allowed_Action.getAll();
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<List<Allowed_Action>> Get (int id)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Allowed_ActionDA allowed_Action = new Allowed_ActionDA(db);
            return allowed_Action.getById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<object> Create (Allowed_Action allowed_Action)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Allowed_ActionDA allowed_ActionDA = new Allowed_ActionDA(db);
            var res = allowed_ActionDA.create(allowed_Action);
            return new
            {
                result = res
            }; 
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult<object> Delete (Allowed_Action allowed_Action)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Allowed_ActionDA allowed_ActionDA = new Allowed_ActionDA(db);
            var res = allowed_ActionDA.delete(allowed_Action);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<object> Update (Allowed_Action allowed_Action)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Allowed_ActionDA allowed_ActionDA = new Allowed_ActionDA(db);
            var res = allowed_ActionDA.update(allowed_Action);
            return new
            {
                result = res
            };
        }
    }
}