using AttachMore.NetGen.Core.Security.Auth;
using AttachMore.NextGen.Core.DomainModels.Account;
using AttachMore.NextGen.Core.IRepositories.Account;
using AttachMore.NextGen.Core.IServices.Account;
using AttachMore.NextGen.Infrastructure.Component.Constants;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account;
using AttachMore.NextGen.Infrastructure.DataAccess.Extentions;
using AttachMore.NextGen.Infrastructure.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Services.Account
{
    /// <summary>
    /// AccountService
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IServices.Account.IAccountService" />
    public class AccountService : IAccountService
    {
        /// <summary>
        /// The m account repository
        /// </summary>
        public IAccountRepository m_AccountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="AccountRepository">The account repository.</param>
        public AccountService(IAccountRepository AccountRepository)
        {
            this.m_AccountRepository = AccountRepository;
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public UserModel GetUserInfo(string email)
        {
            try
            {
                var user = this.m_AccountRepository.Query<User>().Where(a => a.Email == email).FirstOrDefault();
                if (user != null)
                {
                    var model = new UserModel()
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        Id = user.Id,
                        IsDeleted = user.IsDeleted,
                        LastName = user.LastName,
                        PhoneNumber = user.PhoneNumber
                    };
                    return model;
                }
                return new UserModel();
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Resets the passwrod.
        /// </summary>
        /// <param name="newPassword">The new password.</param>
        /// <param name="confirmPassword">The confirm password.</param>
        public string ResetPasswrod(string newPassword, string confirmPassword, string email)
        {
            try
            {
                if (newPassword != confirmPassword)
                {
                    return "New password and Confirm password are missmatched";
                }

                var userInfo = m_AccountRepository.GetAll().Where(a => a.Email == email).FirstOrDefault();
                userInfo.Password = newPassword.Encrypt();
                m_AccountRepository.Edit(userInfo);
                return "Success";
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="email">The email.</param>
        public string ForgotPassword(string email)
        {
            try
            {
                var result = MailHelper.SendMail(email, MailBody(email), Subject);
                return result;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Mails the body.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string MailBody(string email)
        {
            try
            {
                TokenBuilder tokenBuilder = new TokenBuilder();

                var user = this.m_AccountRepository.Query<User>().Where(a => a.Email == email).FirstOrDefault();
                var token = tokenBuilder.Build(user, DateTime.Now.AddDays(1));
                return "Please reset your password here" + System.Environment.NewLine + URL + token;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string URL
        {
            get
            {
                return Constant.ResetPassword;
                //if (Host != null)
                //{
                //    buildhost = Host != "localhost" ? Host : Host + ":" + Port;
                //    return Scheme + "://" + buildhost + "/account/ResetPassword#token=";
                //}
                //else
                //{
                //    buildhost = "attachmore.incredtech.com";
                //    return Scheme + "://" + buildhost + "/account/ResetPassword#token=";
                //}
            }
        }

        /// <summary>
        /// Gets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject
        {
            get
            {
                return Constant.Subject;
            }
        }
    }
}
