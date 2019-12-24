using AttachMore.NetGen.Core.Security.Auth;
using AttachMore.NextGen.Core.DomainModels.Account;
using AttachMore.NextGen.Core.DomainModels.Login;
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
    /// Register Service
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Services.BaseService{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account.User}" />
    /// <seealso cref="AttachMore.NextGen.Core.IServices.Account.IRegisterService" />
    public class RegisterService : IRegisterService
    {
        IRegisterRepository m_IRegisterRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterService"/> class.
        /// </summary>
        /// <param name="IRegisterRepository">The i register repository.</param>
        public RegisterService(IRegisterRepository IRegisterRepository)
        {
            m_IRegisterRepository = IRegisterRepository;
        }

        /// <summary>
        /// Adds the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="BadRequestException">The username is already in use</exception>
        public UserWithTokenModel Add(RegisterModel entity)
        {
            User user = new User()
            {
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Password = entity.Password.Encrypt(),
                PhoneNumber = entity.PhoneNumber,
                IsDeleted = entity.IsDeleted,
                PremiumStatus = false
            };

            var username = user.Email.Trim();

            if (GetQuery().Any(u => u.Email == username))
            {
                throw new BadRequestException("The username is already in use");
            }

            AddUserRoles(user, user.Roles);
            m_IRegisterRepository.Add(user);

            return GetAUthenticate(entity.Email, entity.Password);
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
        public UserWithTokenModel GetAUthenticate(string Email, string password)
        {
            try
            {
                TokenBuilder m_tokenBuilder = new TokenBuilder();

                var user = (from u in m_IRegisterRepository.Query<User>()
                            where u.Email == Email && !u.IsDeleted
                            select u)
                    .Include(x => x.Roles)
                    .ThenInclude(x => x.Role)
                    .FirstOrDefault();

                if (user == null)
                {
                    throw new BadRequestException("username/password aren't right");
                }

                //if (string.IsNullOrWhiteSpace(entity.Password) || user.Password.Decrypt() != entity.Password)
                //{
                //    throw new BadRequestException("username/password aren't right");
                //}

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
                PhoneNumber = Model.PhoneNumber,
                PremiumStatus = Model.PremiumStatus
            };
        }

        /// <summary>
        /// Adds the user roles.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleNames">The role names.</param>
        /// <exception cref="NotFoundException">Role - {roleName}</exception>
        private void AddUserRoles(User user, IList<UserRole> roleNames)
        {
            user.Roles.Clear();

            foreach (var roleName in roleNames)
            {
                var role = m_IRegisterRepository.Query<Role>().FirstOrDefault(x => x.Name == roleName.Role.Name);

                if (role == null)
                {
                    throw new NotFoundException($"Role - {roleName} is not found");
                }

                user.Roles.Add(new UserRole { User = user, Role = role });
            }
        }

        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <returns></returns>
        private IQueryable<User> GetQuery()
        {
            var result = m_IRegisterRepository.GetAll().Where(x => !x.IsDeleted)
                .Include(x => x.Roles)
                    .ThenInclude(x => x.Role);
            return result;
        }
    }
}
