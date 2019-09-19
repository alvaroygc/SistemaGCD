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
            var res = usersDA.Login(users.Email, users.Pass);

            MailService mail = new MailService();

            Token token = new Token
            {
                text = Guid.NewGuid().ToString(),
                created_dt = DateTime.Now,
                expired_dt = DateTime.Now.AddHours(TOKEN_EXP_HOURS),
                id_User = res[0].Id,
                status = "ACTIVE"
                
            };

            var re = usersDA.create_Token(token);

            mail.SendMail(users.Email, token.text);

            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Token")]
        public ActionResult<object> Token (Token token)
        {

            AppDB db = provider.GetRequiredService<AppDB>();
            UsersDA usersDA = new UsersDA(db);
            var res = usersDA.Token(token.text);
            if (res.Count <= 0) {
                return "error ";
            }

            if (res[0].status == "USED" && res[0].expired_dt < DateTime.Now) {
                return "Token Usado o Expirado";
            }
            var ST_Token = usersDA.Desative_Token(token);

            return new
            {
                result = res
            };
        }

    }
}