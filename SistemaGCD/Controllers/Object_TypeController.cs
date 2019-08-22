using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SistemaGCD.Models.DataAccess;
using SistemaGCD.Models.Entities;


namespace SistemaGCD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Object_TypeController : ControllerBase
    {
        private IServiceProvider provider;

        public Object_TypeController (IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Object_Type>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            Object_TypeDA object_Type = new Object_TypeDA(db);
            return object_Type.getAll();
        }
        
        [HttpGet]
        [Route("getById")]
        public ActionResult<List<Object_Type>> Get (int id)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Object_TypeDA object_Type = new Object_TypeDA(db);
            return object_Type.GetById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<object> Create (Object_Type object_Type)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Object_TypeDA object_TypeDA = new Object_TypeDA(db);
            var res = object_TypeDA.create(object_Type);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult<object> Delete(Object_Type object_Type)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Object_TypeDA object_TypeDA = new Object_TypeDA(db);
            var res = object_TypeDA.delete(object_Type);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<object> Update(Object_Type object_Type)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Object_TypeDA object_TypeDA = new Object_TypeDA(db);
            var res = object_TypeDA.update(object_Type);
            return new
            {
                result = res
            };
        }
    }
}