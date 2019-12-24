using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AttachMore.NextGen.Core.DomainModels.Attachment;
using AttachMore.NextGen.Core.Framework.Attributes;
using AttachMore.NextGen.Core.IServices.Attachment;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using AttachMore.NextGen.Service.API.Controllers.Account;
using AttachMore.NextGen.ServiceFactory.Attachment;
using AttachMore.NextGen.ServiceModel.Request.Attachment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttachMore.NextGen.Service.API.Controllers.Attachment
{
    /// <summary>
    /// AttachmentsController Controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    public class AttachmentsController : Controller
    {
        private readonly IAttachmentsService m_AttachmentsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentsController"/> class.
        /// </summary>
        /// <param name="AttachmentService">The attachment service.</param>
        public AttachmentsController(IAttachmentsService AttachmentService)
        {
            this.m_AttachmentsService = AttachmentService;
        }

        // GET: api/Attachments
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Posts the specified request.
        /// </summary>
        /// <param name="Request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] AttachmentsModel entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var UserEmail = User.Claims.Where(a => a.Type == ClaimTypes.Email).Select(a => a.Value).FirstOrDefault(); ;
                    var result = this.m_AttachmentsService.Add(entity, UserEmail, "Web");
                    return new OkObjectResult(result);
                }
                return new BadRequestObjectResult(ModelState);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }

        /// <summary>
        /// Updates the name of the attachment.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [HttpPost("EditAttachmentName")]
        public IActionResult UpdateAttachmentName([FromForm] string AttachmentName, int attachmentId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var UserEmail = User.Claims.Where(a => a.Type == ClaimTypes.Email).Select(a => a.Value).FirstOrDefault(); ;
                    var result = this.m_AttachmentsService.Update(AttachmentName, attachmentId, UserEmail);
                    return new OkObjectResult(result);
                }
                return new BadRequestObjectResult(ModelState);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        /// <summary>
        /// Gets the attachment.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("PreviewAttachments")]
        public IActionResult PreviewAttachments(int Id)
        {
            try
            {
                var result = this.m_AttachmentsService.GetAttachmentDetail(Id);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpPost("DownloadAttachments")]
        public IActionResult DownloadAttachments([FromBody] AttachmentDownloadRequest entity)
        {
            try
            {
                var UserEmail = User.Claims.Where(a => a.Type == ClaimTypes.Email).Select(a => a.Value).FirstOrDefault(); ;

                var AttachmentResult = this.m_AttachmentsService.DownloadAttachment(entity, UserEmail);

                if (AttachmentResult == null)
                {
                    throw new UnauthorizedAccessException("You are not Autherized to access this Attachment.");
                }

                if (AttachmentResult.AttachmentBytes == null || AttachmentResult.AttachmentBytes.Length == 0)
                {
                    return new NotFoundObjectResult("Attachment not found");
                }

                if (AttachmentResult.FileCount > 1)
                {
                    HttpContext.Response.ContentType = AttachmentResult.FileType;
                    var result = new FileContentResult(AttachmentResult.AttachmentBytes, AttachmentResult.FileType)
                    {
                        FileDownloadName = "Attachment.zip"
                    };
                    return result;
                }
                else
                {
                    HttpContext.Response.ContentType = AttachmentResult.FileType;
                    var result = new FileContentResult(AttachmentResult.AttachmentBytes, "application/octet-stream")
                    {
                        FileDownloadName = AttachmentResult.FileName,
                    };
                    return result;
                }
                //return File(AttachmentResult.AttachmentBytes, "application/octet-stream");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
