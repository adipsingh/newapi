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
    /// AttachmentExpirySettingsController Controller Class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentExpirySettingsController : ControllerBase
    {

        /// <summary>
        /// The m expiry settings service
        /// </summary>
        IAttachmentExpirySettingsService m_ExpirySettingsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentExpirySettingsController"/> class.
        /// </summary>
        /// <param name="ExpirySettingsService">The expiry settings service.</param>
        public AttachmentExpirySettingsController(IAttachmentExpirySettingsService ExpirySettingsService)
        {
            this.m_ExpirySettingsService = ExpirySettingsService;
        }

        // POST: api/AttachmentExpirySettings
        /// <summary>
        /// Posts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] AttachmentExpirySettingsModel request)
        {
            try
            {
                var response = this.m_ExpirySettingsService.Add(request);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
