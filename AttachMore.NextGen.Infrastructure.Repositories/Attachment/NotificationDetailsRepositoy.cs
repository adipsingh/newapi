using AttachMore.NextGen.Core.IRepositories.Attachment;
using AttachMore.NextGen.Infrastructure.DataAccess.Context;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Repositories.Attachment
{
    /// <summary>
    /// Notification Details Repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment.NotificationDetails, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.Attachment.INotificationDetailsRepository" />
    public class NotificationDetailsRepositoy : Repository<NotificationDetails, NextGenContext>, INotificationDetailsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationDetailsRepositoy"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NotificationDetailsRepositoy(NextGenContext context)
            : base(context)
        {
        }
    }
}
