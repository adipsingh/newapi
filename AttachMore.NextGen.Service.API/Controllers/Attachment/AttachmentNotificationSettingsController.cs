using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttachMore.NextGen.Core.DomainModels.Attachment;
using AttachMore.NextGen.Core.IServices.Attachment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttachMore.NextGen.Service.API.Controllers.Attachment
{
    /// <summary>
    /// AttachmentNotificationSettingsController Controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentNotificationSettingsController : ControllerBase
    {
        /// <summary>
        /// The m service
        /// </summary>
        IAttachmentNotificationSettingsService m_Service;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentNotificationSettingsController"/> class.
        /// </summary>
        public AttachmentNotificationSettingsController(IAttachmentNotificationSettingsService Service)
        {
            this.m_Service = Service;
        }

        [HttpGet()]
        public string Get()
        {
            return "Hello";
        }

        // POST: api/AttachmentNotificationSettings
        /// <summary>
        /// Posts the specified request.
        /// </summary>
        /// <param name="Request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] AttachmentNotificationSettingsModel Request)
        {
            try
            {
                var response = this.m_Service.Add(Request);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
