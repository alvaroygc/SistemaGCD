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
    public class CasesController : ControllerBase
    {
        private IServiceProvider provider;

        public CasesController(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Case>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            CaseDA cases = new CaseDA(db);
            return cases.getAll();
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<List<Case>> Get(int id)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            CaseDA cases = new CaseDA(db);
            return cases.getById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<object> Create(Case cases)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            CaseDA casesDA = new CaseDA(db);
            var res = casesDA.create(cases);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult<object> Delete(Case cases)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            CaseDA casesDA = new CaseDA(db);
            var res = casesDA.delete(cases);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<object> Update(Case cases)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            CaseDA casesDA = new CaseDA(db);
            var res = casesDA.update(cases);
            return new
            {
                result = res
            };
        }
    }
}