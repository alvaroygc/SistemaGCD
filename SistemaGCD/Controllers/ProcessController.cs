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
    public class ProcessController : ControllerBase
    {
        private IServiceProvider provider;

        public ProcessController(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Process>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            ProcessDA process = new ProcessDA(db);
            return process.getAll();
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<List<Process>> Get(int id)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            ProcessDA process = new ProcessDA(db);
            return process.getById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<object> Create(Process process)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            ProcessDA processDA = new ProcessDA(db);
            var res = processDA.create(process);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult<object> Delete(Process process)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            ProcessDA processDA = new ProcessDA(db);
            var res = processDA.delete(process);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<object> Update(Process process)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            ProcessDA processDA = new ProcessDA(db);
            var res = processDA.update(process);
            return new
            {
                result = res
            };
        }
    }
}