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
    public class SuscriptionController : ControllerBase
    {
        private IServiceProvider provider;

        public SuscriptionController(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Suscription>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            SuscriptionDA suscription = new SuscriptionDA(db);
            return suscription.getAll();
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<List<Suscription>> Get(int id)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            SuscriptionDA suscription = new SuscriptionDA(db);
            return suscription.getById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<object> Create(Suscription suscription)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            SuscriptionDA suscriptionDA = new SuscriptionDA(db);
            var res = suscriptionDA.create(suscription);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult<object> Delete(Suscription suscription)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            SuscriptionDA suscriptionDA = new SuscriptionDA(db);
            var res = suscriptionDA.delete(suscription);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<object> Update(Suscription suscription)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            SuscriptionDA suscriptionDA = new SuscriptionDA(db);
            var res = suscriptionDA.update(suscription);
            return new
            {
                result = res
            };
        }
    }
}