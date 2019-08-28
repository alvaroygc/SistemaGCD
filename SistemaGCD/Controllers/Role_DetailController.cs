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
    public class Role_DetailController : ControllerBase
    {
        private IServiceProvider provider;

        public Role_DetailController(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Role_Detail>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            Role_DetailDA role_Detail = new Role_DetailDA(db);
            return role_Detail.getAll();
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<List<Role_Detail>> Get(int id)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Role_DetailDA role_Detail = new Role_DetailDA(db);
            return role_Detail.GetById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<object> Create(Role_Detail role_Detail)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Role_DetailDA role_DetailDA = new Role_DetailDA(db);
            var res = role_DetailDA.create(role_Detail);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult<object> Delete(Role_Detail role_Detail)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Role_DetailDA role_DetailDA = new Role_DetailDA(db);
            var res = role_DetailDA.delete(role_Detail);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<object> Update(Role_Detail role_Detail)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Role_DetailDA role_DetailDA = new Role_DetailDA(db);
            var res = role_DetailDA.update(role_Detail);
            return new
            {
                result = res
            };
        }
    }
}