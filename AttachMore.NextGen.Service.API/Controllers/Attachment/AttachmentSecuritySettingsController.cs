using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttachMore.NextGen.Core.DomainModels.Attachment;
using AttachMore.NextGen.Core.IServices.Attachment;
using AttachMore.NextGen.Infrastructure.Services.Attachment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttachMore.NextGen.Service.API.Controllers.Attachment
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentSecuritySettingsController : ControllerBase
    {
        /// <summary>
        /// The m i attachment security settings servoce
        /// </summary>
        IAttachmentSecuritySettingsService m_IAttachmentSecuritySettingsServoce;

        public AttachmentSecuritySettingsController(IAttachmentSecuritySettingsService AttachmentSecuritySettingsServoce)
        {
            this.m_IAttachmentSecuritySettingsServoce = AttachmentSecuritySettingsServoce;
        }

        [HttpGet]
        public string get()
        {
            return "Hello";
        }

        /// <summary>
        /// Gets the security settings.
        /// </summary>
        /// <param name="AttachmentId">The attachment identifier.</param>
        /// <returns></returns>
        [HttpGet("GetSecuritySettings")]
        public IActionResult GetSecuritySettings(int AttachmentId)
        {
            try
            {
                var response = this.m_IAttachmentSecuritySettingsServoce.GetSecuritySettings(AttachmentId);
                if (response == null)
                {
                    return new NotFoundObjectResult("Attachment Security Settings Not found");
                }
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        // POST: api/AttachmentSecuritySettings
        [HttpPost]
        public IActionResult Post([FromBody] AttachmentSecuritySettingsModel request)
        {
            try
            {
                var response = this.m_IAttachmentSecuritySettingsServoce.Add(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
