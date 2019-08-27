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
    public class Sec_ObjectsController : ControllerBase
    {
        private IServiceProvider provider;

        public Sec_ObjectsController(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Sec_Object>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            Sec_ObjectsDA sec_Objects= new Sec_ObjectsDA(db);
            return sec_Objects.getAll();
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<List<Sec_Object>> Get(int id)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Sec_ObjectsDA sec_Objects = new Sec_ObjectsDA(db);
            return sec_Objects.getById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<object> Create(Sec_Object sec_Object)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Sec_ObjectsDA sec_ObjectsDA = new Sec_ObjectsDA(db);
            var res = sec_ObjectsDA.create(sec_Object);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult<object> Delete(Sec_Object sec_Object)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Sec_ObjectsDA sec_ObjectsDA = new Sec_ObjectsDA(db);
            var res = sec_ObjectsDA.delete(sec_Object);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<object> Update(Sec_Object sec_Object)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Sec_ObjectsDA sec_ObjectsDA = new Sec_ObjectsDA(db);
            var res = sec_ObjectsDA.update(sec_Object);
            return new
            {
                result = res
            };
        }
    }
}