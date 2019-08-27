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
    public class RolesController : ControllerBase
    {
        private IServiceProvider provider;

        public RolesController(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Roles>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            RolesDA roles = new RolesDA(db);
            return roles.getAll();
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<List<Roles>> Get(int id)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            RolesDA roles = new RolesDA(db);
            return roles.getById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<object> Create(Roles roles)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            RolesDA rolesDA = new RolesDA(db);
            var res = rolesDA.create(roles);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult<object> Delete(Roles roles)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            RolesDA rolesDA = new RolesDA(db);
            var res = rolesDA.delete(roles);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<object> Update(Roles roles)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            RolesDA rolesDA = new RolesDA(db);
            var res = rolesDA.update(roles);
            return new
            {
                result = res
            };
        }
    }
}