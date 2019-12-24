using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.GuestLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AttachMore.NextGen.Core.IRepositories.GuestLink
{
    /// <summary>
    /// IGustLinkRepository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.IRepository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.GuestLink.GuestLinks}" />
    public interface IGuestLinkRepository : IRepository<GuestLinks>
    {
    }
}
