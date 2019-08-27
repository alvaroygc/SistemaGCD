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
    public class UsersController : ControllerBase
    {
        private IServiceProvider provider;

        public UsersController(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Users>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            UsersDA users = new UsersDA(db);
            return users.getAll();
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<List<Users>> Get(int id)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            UsersDA users = new UsersDA(db);
            return users.getById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<object> Create(Users users)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            UsersDA usersDA = new UsersDA(db);
            var res = usersDA.create(users);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult<object> Delete(Users users)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            UsersDA usersDA = new UsersDA(db);
            var res = usersDA.delete(users);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<object> Update(Users users)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            UsersDA usersDA = new UsersDA(db);
            var res = usersDA.update(users);
            return new
            {
                result = res
            };
        }
    }
}