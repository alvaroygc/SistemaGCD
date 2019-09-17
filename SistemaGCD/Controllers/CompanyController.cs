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
    public class CompanyController : ControllerBase
    {
        private IServiceProvider provider;

        public CompanyController(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Company>> Get()
        {
            AppDB db = provider.GetService<AppDB>();
            CompanyDA company = new CompanyDA(db);
            return company.getAll();
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<List<Company>> Get(int id)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            CompanyDA company = new CompanyDA(db);
            return company.getById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<object> Create(Company company)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            CompanyDA companyDA = new CompanyDA(db);
            var res = companyDA.create(company);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult<object> Delete(Company company)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            CompanyDA companyDA = new CompanyDA(db);
            var res = companyDA.delete(company);
            return new
            {
                result = res
            };
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<object> Update(Company company)
        {
            AppDB db = provider.GetRequiredService<AppDB>();
            CompanyDA companyDA = new CompanyDA(db);
            var res = companyDA.update(company);
            return new
            {
                result = res
            };
        }
    }
}