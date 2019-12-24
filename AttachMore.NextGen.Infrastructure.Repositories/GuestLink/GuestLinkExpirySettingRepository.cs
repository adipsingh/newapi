using AttachMore.NextGen.Core.IRepositories.GuestLink;
using AttachMore.NextGen.Infrastructure.DataAccess.Context;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.GuestLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Repositories.GuestLink
{
    /// <summary>
    /// GuestLink Expiry Settings Repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.GuestLink.GuestLinks_ExpirySettings, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.GuestLink.IGuestLinkExpirySettingsRepository" />
    public class GuestLinkExpirySettingRepository : Repository<GuestLinks_ExpirySettings, NextGenContext>, IGuestLinkExpirySettingsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestLinkExpirySettingRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GuestLinkExpirySettingRepository(NextGenContext context)
            : base(context)
        {
        }
    }
}
