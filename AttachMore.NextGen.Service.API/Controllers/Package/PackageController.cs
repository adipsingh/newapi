using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttachMore.NextGen.Core.DomainModels.Package;
using AttachMore.NextGen.Core.IServices.Package;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttachMore.NextGen.Service.API.Controllers.Package
{
    /// <summary>
    /// package Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PackageController : ControllerBase
    {
        /// <summary>
        /// The m package service
        /// </summary>
        private readonly IPackageService m_PackageService;

        public PackageController(IPackageService packageService)
        {
            this.m_PackageService = packageService;
        }

        // GET: api/Package
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Package/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = this.m_PackageService.GetAllPackage();
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        // POST: api/Package
        [HttpPost]
        public IActionResult Post([FromBody] UserPackagesModel model)
        {
            try
            {
                var result = this.m_PackageService.AddUserPackage(model);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        // PUT: api/Package/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
