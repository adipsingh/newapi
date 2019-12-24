using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AttachMore.NextGen.Core.DomainModels.Attachment;
using AttachMore.NextGen.Core.DomainModels.GuestLink;
using AttachMore.NextGen.Core.IServices.Attachment;
using AttachMore.NextGen.Core.IServices.GuestLink;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttachMore.NextGen.Service.API.Controllers.GuestLink
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GuestLinkController : ControllerBase
    {
        /// <summary>
        /// The m guest link service
        /// </summary>
        private readonly IGuestLinkService m_GuestLinkService;

        /// <summary>
        /// The m attachments service
        /// </summary>
        private readonly IAttachmentsService m_AttachmentsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestLinkController"/> class.
        /// </summary>
        /// <param name="guestLinkService">The guest link service.</param>
        public GuestLinkController(IGuestLinkService guestLinkService, IAttachmentsService AttachmentsService)
        {
            this.m_GuestLinkService = guestLinkService;
            this.m_AttachmentsService = AttachmentsService;
        }

        // GET: api/GuestLink
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.Where(a => a.Type == "UserId").Select(a => a.Value).FirstOrDefault());
                var result = this.m_GuestLinkService.GetAllGuests(UserId);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }


        // POST: api/GuestLink
        [HttpPost]
        public IActionResult Post([FromBody] GuestLinksModel model)
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.Where(a => a.Type == "UserId").Select(a => a.Value).FirstOrDefault());
                model.UserId = UserId;
                var result = this.m_GuestLinkService.AddGustLink(model);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        /// <summary>
        /// Posts the specified request.
        /// </summary>
        /// <param name="Request">The request.</param>
        /// <returns></returns>
        [HttpPost("Upload")]
        [AllowAnonymous]
        public IActionResult UploadGuestAttachment([FromBody] GuestAttachmentModel entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var UserEmail = User.Claims.Where(a => a.Type == ClaimTypes.Email).Select(a => a.Value).FirstOrDefault();
                    var result = this.m_AttachmentsService.Add(entity, UserEmail, "Guest");
                    return new OkObjectResult(result);
                }
                return new BadRequestObjectResult(ModelState);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
