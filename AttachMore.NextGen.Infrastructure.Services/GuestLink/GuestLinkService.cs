using AttachMore.NextGen.Core.DomainModels.Account;
using AttachMore.NextGen.Core.DomainModels.ApplicationSettings;
using AttachMore.NextGen.Core.DomainModels.GuestLink;
using AttachMore.NextGen.Core.IRepositories.GuestLink;
using AttachMore.NextGen.Core.IServices.Account;
using AttachMore.NextGen.Core.IServices.GuestLink;
using AttachMore.NextGen.Infrastructure.Component.Mapper;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.GuestLink;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Services.GuestLink
{
    /// <summary>
    /// Guest Link Service
    /// </summary>
    public class GuestLinkService : IGuestLinkService
    {
        /// <summary>
        /// The m guest link repository
        /// </summary>
        private readonly IGuestLinkRepository m_GuestLinkRepository;

        /// <summary>
        /// The m guest link expiry setting repo
        /// </summary>
        private readonly IGuestLinkExpirySettingsRepository m_GuestLinkExpirySettingRepo;

        /// <summary>
        /// The m guest link security settings repo
        /// </summary>
        private readonly IGuestLinkSecuritySettingsRepository m_GuestLinkSecuritySettingsRepo;

        /// <summary>
        /// The m account service
        /// </summary>
        private IAccountService m_AccountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestLinkService"/> class.
        /// </summary>
        /// <param name="guestLinkRepository">The guest link repository.</param>
        public GuestLinkService(IGuestLinkRepository guestLinkRepository, IAccountService accountService,
            IGuestLinkExpirySettingsRepository GuestLinkExpirySettingsRepository, IGuestLinkSecuritySettingsRepository GuestLinkSecuritySettingsRepository)
        {
            this.m_GuestLinkRepository = guestLinkRepository;
            this.m_AccountService = accountService;
            this.m_GuestLinkExpirySettingRepo = GuestLinkExpirySettingsRepository;
            this.m_GuestLinkSecuritySettingsRepo = GuestLinkSecuritySettingsRepository;
        }

        /// <summary>
        /// Gets all guests.
        /// </summary>
        /// <param name="Email">The email.</param>
        public List<GuestLinksModel> GetAllGuests(int UserId)
        {
            try
            {
                var Links = this.m_GuestLinkRepository.GetAll().Where(a => a.UserId == UserId).ToList();
                PopUpExpirySettings(ref Links);
                PopulateSecuritySettings(ref Links);

                var result = GuestLinksMapper<GuestLinks, GuestLinksModel>.MapResponse(Links);
                return result;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception("");
            }
        }

        /// <summary>
        /// Pops up expiry settings.
        /// </summary>
        /// <param name="guestLinks">The guest links.</param>
        private void PopUpExpirySettings(ref List<GuestLinks> guestLinks)
        {
            foreach (var item in guestLinks)
            {
                var expiry = this.m_GuestLinkExpirySettingRepo.GetAll().Where(a => a.GustLinkId == item.GuestLinkID).FirstOrDefault();
                if (expiry == null)
                {
                    continue;
                }
                item.ExpirySettings = expiry;
            }
        }

        /// <summary>
        /// Populates the security settings.
        /// </summary>
        /// <param name="guestLinks">The guest links.</param>
        private void PopulateSecuritySettings(ref List<GuestLinks> guestLinks)
        {
            foreach (var item in guestLinks)
            {
                var security = this.m_GuestLinkSecuritySettingsRepo.GetAll().Where(a => a.GustLinkId == item.GuestLinkID).FirstOrDefault();
                if (security == null)
                {
                    continue;
                }
                item.SecuritySettings = security;
            }
        }

        /// <summary>
        /// Adds the gust link.
        /// </summary>
        /// <param name="Model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public GuestLinksModel AddGustLink(GuestLinksModel Model)
        {
            try
            {
                if (Model.GuestLinkID <= 0)
                {
                    if (string.IsNullOrEmpty(Model.LinkUrl))
                    {
                        var GuestId = Guid.NewGuid().ToString("N").Substring(0, 15);
                        var guestLink = string.Format("{0}/{1}", Application.AttachMoreWeb, GuestId);
                        Model.LinkUrl = guestLink;
                        Model.GuestId = GuestId;
                    }
                    else
                    {
                        Model.GuestId = Model.LinkUrl.Substring(Model.LinkUrl.IndexOf("com") + 4).ToString();
                    }

                    var entity = GuestLinksMapper<GuestLinksModel, GuestLinks>.Map(Model);
                    this.m_GuestLinkRepository.Add(entity);
                    this.AddExpirySettings(ref entity);
                    this.AddSecuritySettings(ref entity);

                    Model = GuestLinksMapper<GuestLinks, GuestLinksModel>.Map(entity);
                    return Model;
                }
                else
                {
                    var entity = GuestLinksMapper<GuestLinksModel, GuestLinks>.Map(Model);
                    this.m_GuestLinkRepository.Edit(entity);
                    this.AddExpirySettings(ref entity);
                    this.AddSecuritySettings(ref entity);

                    Model = GuestLinksMapper<GuestLinks, GuestLinksModel>.Map(entity);
                    return Model;
                }                
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Adds the expiry settings.
        /// </summary>
        /// <param name="entity">The entity.</param>
        private void AddExpirySettings(ref GuestLinks entity)
        {
            entity.ExpirySettings.GustLinkId = entity.GuestLinkID;
            this.m_GuestLinkExpirySettingRepo.Add(entity.ExpirySettings);
        }

        /// <summary>
        /// Adds the security settings.
        /// </summary>
        /// <param name="entity">The entity.</param>
        private void AddSecuritySettings(ref GuestLinks entity)
        {
            entity.SecuritySettings.GustLinkId = entity.GuestLinkID;
            this.m_GuestLinkSecuritySettingsRepo.Add(entity.SecuritySettings);
        }

        /// <summary>
        /// Loggeds the in user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        private UserModel LoggedInUser(string email)
        {
            var result = this.m_AccountService.GetUserInfo(email);
            return result;
        }
    }
}
