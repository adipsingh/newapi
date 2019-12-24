using AttachMore.NetGen.Core.Security.Auth;
using AttachMore.NextGen.Core.DomainModels.Account;
using AttachMore.NextGen.Core.Exceptions.APIExceptions;

using AttachMore.NextGen.Core.IRepositories.Account;
using AttachMore.NextGen.Core.IServices.Account;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account;
using AttachMore.NextGen.Infrastructure.DataAccess.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Services.Account
{
    /// <summary>
    /// Login Service Class
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IServices.Account.ILoginService" />
    public class LoginService : BaseService<LoginModel>, ILoginService
    {
        private readonly ILoginRepository m_ILoginRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginService"/> class.
        /// </summary>
        /// <param name="loginRepository">The login repository.</param>
        public LoginService(ILoginRepository loginRepository)
        {
            m_ILoginRepository = loginRepository;
        }

        /// <summary>
        /// Gets a uthenticate.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="BadRequestException">
        /// username/password aren't right
        /// or
        /// username/password aren't right
        /// or
        /// </exception>
        public UserWithTokenModel GetAUthenticate(LoginModel entity)
        {
            try
            {
                TokenBuilder m_tokenBuilder = new TokenBuilder();

                var user = (from u in m_ILoginRepository.Query<User>()
                            where u.Email == entity.Email && !u.IsDeleted
                            select u)
                    .Include(x => x.Roles)
                    .ThenInclude(x => x.Role)
                    .FirstOrDefault();

                if (user == null)
                {
                    throw new BadRequestException("username/password aren't right");
                }

                if (string.IsNullOrWhiteSpace(entity.Password) || user.Password.Decrypt() != entity.Password)
                {
                    throw new BadRequestException("username/password aren't right");
                }

                var expiresIn = DateTime.Now + TokenAuthOption.ExpiresSpan;
                var token = m_tokenBuilder.Build(user, expiresIn);

                return new UserWithTokenModel
                {
                    ExpiresAt = expiresIn,                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
                    Token = token,
                    User = this.MapUser(user)
                };
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Maps the user.
        /// </summary>
        /// <param name="Model">The model.</param>
        /// <returns></returns>
        private UserModel MapUser(User Model)
        {
            return new UserModel()
            {
                Email = Model.Email,
                FirstName = Model.FirstName,
                Id = Model.Id,
                IsDeleted = Model.IsDeleted,
                LastName = Model.LastName,
                PhoneNumber = Model.PhoneNumber
            };
        }
    }
}
