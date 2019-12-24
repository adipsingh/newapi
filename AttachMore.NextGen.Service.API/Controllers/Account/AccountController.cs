using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AttachMore.NextGen.Core.IRepositories.Account;
using AttachMore.NextGen.Core.IServices.Account;
using AttachMore.NextGen.ServiceModel.Request.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttachMore.NextGen.Service.API.Controllers.Account
{
    /// <summary>
    /// AccountController`  
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// The m account repository
        /// </summary>
        private IAccountService m_AccountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="AccountRepository">The account repository.</param>
        public AccountController(IAccountService AccountService)
        {
            this.m_AccountService = AccountService;
        }

        // POST: api/Account
        /// <summary>
        /// Posts the specified email.
        /// </summary>
        /// <param name="Email">The email.</param>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get(string Email)
        {
            try
            {
                if (Email != null)
                {
                    var response = this.m_AccountService.GetUserInfo(Email);
                    //if (response == null)
                    //{
                    //    return new NotFoundObjectResult("User not found");
                    //}
                    return new OkObjectResult(response);
                }
                return BadRequest("Please provide a valid Email");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }



        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPassword entity)
        {
            try
            {
                var userEmail = User.Claims.Where(a => a.Type == ClaimTypes.Email).Select(a => a.Value).FirstOrDefault(); ;
                var result = m_AccountService.ResetPasswrod(entity.NewPassword, entity.ConfirmPassword, userEmail);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        [HttpGet("ForgotPassword")]
        [AllowAnonymous]
        public IActionResult ForgotPassword([FromQuery]string Email)
        {
            try
            {
                var request = HttpContext.Request;
                var _host = request.Host;
                var result = m_AccountService.ForgotPassword(Email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
