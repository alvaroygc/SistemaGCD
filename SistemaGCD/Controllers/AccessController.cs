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
    public class AccessController : ControllerBase
    {
        private readonly string SALT = "S3cur1tyS@lt";
        private readonly int TOKEN_EXP_HOURS = 12;

        private IServiceProvider provider;

        public AccessController(IServiceProvider serviceProvider) {
            provider = serviceProvider;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<object> Login(Users users) {

            AppDB db = provider.GetRequiredService<AppDB>();
            UsersDA usersDA = new UsersDA(db);
            var res = usersDA.login(users);
            return new
            {
                result = res
            };
        }
  
    }
}