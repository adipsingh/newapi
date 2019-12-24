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
    /// Gust Link Repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.GuestLink.GuestLinks, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.GuestLink.IGuestLinkRepository" />
    public class GuestLinkRepository : Repository<GuestLinks, NextGenContext>, IGuestLinkRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestLinkRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GuestLinkRepository(NextGenContext context)
            : base(context)
        {
        }
    }
}
