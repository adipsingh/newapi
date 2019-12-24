using AttachMore.NextGen.Core.DomainModels.Attachment;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Attachment;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Component.Mapper
{
    public class AttachmentNotificationSettingMapper
    {
        public static AttachmentNotificationSettings MapNotification(AttachmentNotificationSettingsModel source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AttachmentNotificationSettingsModel, AttachmentNotificationSettings>();
            });

            IMapper mapper = config.CreateMapper();

            var destination = mapper.Map<AttachmentNotificationSettingsModel, AttachmentNotificationSettings>(source);
            return destination;
        }
    }
}
