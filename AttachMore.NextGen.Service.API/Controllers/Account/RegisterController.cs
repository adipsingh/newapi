using AttachMore.NextGen.Core.DomainModels.Account;
using AttachMore.NextGen.Core.DomainModels.Login;
using AttachMore.NextGen.Core.Framework.Attributes;
using AttachMore.NextGen.Core.IRepositories.Account;
using AttachMore.NextGen.Core.IServices.Account;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account;
using AttachMore.NextGen.ServiceFactory.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Service.API.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    [Factory(Type = typeof(RegisterFactory))]
    public class RegisterController : Controller
    {

        /// <summary>
        /// The m register repository
        /// </summary>
        private readonly IRegisterService m_RegisterRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterController"/> class.
        /// </summary>
        /// <param name="registerRepository">The register repository.</param>
        public RegisterController(IRegisterService registerRepository)
        {
            this.m_RegisterRepository = registerRepository;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Value", "Harjap" };
        }

        /// <summary>
        /// Posts the specified request.
        /// </summary>
        /// <param name="Request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] RegisterModel Request)
        {
            if (ModelState.IsValid)
            {
                if (Request.Password == Request.ConfirmPassword)
                {
                    var model = this.m_RegisterRepository.Add(Request);
                    return new OkObjectResult(model);
                }
                return BadRequest("Both passwords should match.");
            }
            return BadRequest(ModelState);
        }
    }
}
