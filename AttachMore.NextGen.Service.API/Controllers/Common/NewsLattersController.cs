using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttachMore.NextGen.Core.DomainModels.Common;
using AttachMore.NextGen.Core.IServices.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttachMore.NextGen.Service.API.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsLattersController : ControllerBase
    {
        private readonly INewsLettersService m_NewsLettersService;

        public NewsLattersController(INewsLettersService service)
        {
            this.m_NewsLettersService = service;
        }

        // POST: api/NewsLatters
        [HttpPost()]
        public IActionResult Post([FromBody] NewsLettersModel model)
        {
            try
            {
                var result = this.m_NewsLettersService.Add(model);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
