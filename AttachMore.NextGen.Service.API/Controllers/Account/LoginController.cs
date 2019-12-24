using AttachMore.NextGen.Core.DomainModels.Account;
using AttachMore.NextGen.Core.Framework.Attributes;
using AttachMore.NextGen.Core.IRepositories.Account;
using AttachMore.NextGen.Core.IServices.Account;
using AttachMore.NextGen.ServiceFactory.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Service.API.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    [Factory(Type = typeof(LoginFactory))]
    public class LoginController : Controller
    {
        private readonly ILoginService m_LoginService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="loginRepository">The login repository.</param>
        public LoginController(ILoginService loginService)
        {
            this.m_LoginService = loginService;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        //[Authorize]
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
        public IActionResult Post([FromBody] LoginModel Request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = this.m_LoginService.GetAUthenticate(Request);
                    return new OkObjectResult(model);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
