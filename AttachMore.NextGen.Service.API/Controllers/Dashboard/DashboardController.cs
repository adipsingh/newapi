using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AttachMore.NextGen.Core.IServices.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttachMore.NextGen.Service.API.Controllers.Dashboard
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        /// <summary>
        /// The m dashboard service
        /// </summary>
        private readonly IDashboardService m_DashboardService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardController"/> class.
        /// </summary>
        public DashboardController(IDashboardService DashboardService)
        {
            m_DashboardService = DashboardService;
        }

        // GET: api/Dashboard
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Stats")]
        public IActionResult Stats()
        {
            try
            {
                var email = User.Claims.Where(a => a.Type == ClaimTypes.Email).Select(a => a.Value).FirstOrDefault();;
                var states = m_DashboardService.DashboadStats(email);
                return new OkObjectResult(states);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }

        /// <summary>
        /// Histories this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet("History")]
        public IActionResult History()
        {
            try
            {
                var email = User.Claims.Where(a => a.Type == ClaimTypes.Email).Select(a => a.Value).FirstOrDefault();;
                var history = m_DashboardService.AttachmentHistory(email);
                return new OkObjectResult(history);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        /// <summary>
        /// Attachments the files.
        /// </summary>
        /// <param name="AttachmentId">The attachment identifier.</param>
        /// <returns></returns>
        [HttpGet("FilesDetail")]
        public IActionResult AttachmentFiles(int AttachmentId)
        {
            try
            {
                var loggedInUserEmail = User.Claims.Where(a => a.Type == ClaimTypes.Email).Select(a => a.Value).FirstOrDefault();;
                var result = this.m_DashboardService.AttachmentFilesDetail(AttachmentId, loggedInUserEmail);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        /// <summary>
        /// Users the details.
        /// </summary>
        /// <returns></returns>
        [HttpGet("UserDetail")]
        public IActionResult UserDetails()
        {
            try
            {
                var Email = User.Claims.Where(a => a.Type == ClaimTypes.Email).Select(a => a.Value).FirstOrDefault();
                var result = this.m_DashboardService.DashboardUserInfo(Email);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        /// <summary>
        /// Datas the usage.
        /// </summary>
        /// <returns></returns>
        [HttpGet("DataUsage")]
        public IActionResult DataUsage()
        {
            try
            {
                var email = User.Claims.Where(a => a.Type == ClaimTypes.Email).Select(a => a.Value).FirstOrDefault();;
                var result = this.m_DashboardService.DashboardDataUsage(email);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
