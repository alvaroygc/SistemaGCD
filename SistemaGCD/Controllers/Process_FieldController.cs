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
    public class Process_FieldController : ControllerBase
    {
        private IServiceProvider provider;

        public Process_FieldController(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Process_Field>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            Process_FieldDA process_Field = new Process_FieldDA(db);
            return process_Field.getAll();
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<List<Process_Field>> Get(int id)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Process_FieldDA process_Field = new Process_FieldDA(db);
            return process_Field.getById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<object> Create(Process_Field process_Field)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Process_FieldDA process_FieldDA = new Process_FieldDA(db);
            var res = process_FieldDA.create(process_Field);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult<object> Delete(Process_Field process_Field)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Process_FieldDA process_FieldDA = new Process_FieldDA(db);
            var res = process_FieldDA.delete(process_Field);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<object> Update(Process_Field process_Field)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            Process_FieldDA process_FieldDA = new Process_FieldDA(db);
            var res = process_FieldDA.update(process_Field);
            return new
            {
                result = res
            };
        }
    }
}