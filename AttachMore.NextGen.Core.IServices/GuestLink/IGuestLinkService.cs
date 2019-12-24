using AttachMore.NextGen.Core.DomainModels.GuestLink;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.GuestLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IServices.GuestLink
{
    /// <summary>
    /// IGuest Link service
    /// </summary>
    public interface IGuestLinkService
    {
        /// <summary>
        /// Gets all guests.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        List<GuestLinksModel> GetAllGuests(int UserId);

        /// <summary>
        /// Adds the gust link.
        /// </summary>
        /// <param name="Model">The model.</param>
        /// <returns></returns>
        GuestLinksModel AddGustLink(GuestLinksModel Model);
    }
}
