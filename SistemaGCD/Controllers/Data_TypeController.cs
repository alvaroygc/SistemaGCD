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
    public class Data_TypeController : ControllerBase
    {
        private IServiceProvider provider;

        public Data_TypeController(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Data_Type>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            Data_TypeDA data_Type = new Data_TypeDA(db);
            return data_Type.getAll();
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<List<Data_Type>> Get(int id)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Data_TypeDA data_Type = new Data_TypeDA(db);
            return data_Type.getById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<object> Create(Data_Type data_Type)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Data_TypeDA data_TypeDA = new Data_TypeDA(db);
            var res = data_TypeDA.create(data_Type);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult<object> Delete(Data_Type data_Type)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Data_TypeDA data_TypeDA = new Data_TypeDA(db);
            var res = data_TypeDA.delete(data_Type);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<object> Update(Data_Type data_Type)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Data_TypeDA data_TypeDA = new Data_TypeDA(db);
            var res = data_TypeDA.update(data_Type);
            return new
            {
                result = res
            };
        }
    }
}