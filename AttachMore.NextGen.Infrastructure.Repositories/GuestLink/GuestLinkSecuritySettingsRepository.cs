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
    /// GuestLink Security Settings Repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.GuestLink.GuestLinks_SecuritySettings, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.GuestLink.IGuestLinkSecuritySettingsRepository" />
    public class GuestLinkSecuritySettingsRepository : Repository<GuestLinks_SecuritySettings, NextGenContext>, IGuestLinkSecuritySettingsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestLinkSecuritySettingsRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GuestLinkSecuritySettingsRepository(NextGenContext context)
            : base(context)
        {
        }
    }
}
