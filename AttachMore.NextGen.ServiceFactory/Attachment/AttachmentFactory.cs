using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using AttachMore.NextGen.ServiceModel.Request.Attachment;
using AttachMore.NextGen.ServiceModel.Response.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.ServiceFactory.Attachment
{
    public class AttachmentFactory : FactoryBase<Attachments, AttachmentsRequest, AttachmentsResponse>
    {
        public override Attachments MapRequest(params object[] parameters)
        {
            var attachment = new Attachments()
            {
                AccountId = this.RequestObject.AccountId,
                DeletedOn = this.RequestObject.DeletionDate,
                DownloadUrl = this.RequestObject.DownloadUrl,
                ExpiriedOn = this.RequestObject.ExpiryDate,
                Name = this.RequestObject.Name,
                TotalSize = this.RequestObject.Size,
                Status = this.RequestObject.Status,
                UserId = this.RequestObject.UserId
            };
            return attachment;
        }
    }
}
