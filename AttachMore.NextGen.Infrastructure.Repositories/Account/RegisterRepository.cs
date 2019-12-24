using AttachMore.NextGen.Core.Exceptions.APIExceptions;
using AttachMore.NextGen.Core.IRepositories.Account;
using AttachMore.NextGen.Infrastructure.DataAccess.Context;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Repositories.Account
{
    /// <summary>
    /// Register repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account.User}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.Account.IRegisterRepository" />
    public class RegisterRepository : Repository<User, NextGenContext>, IRegisterRepository
    {
        NextGenContext _context = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RegisterRepository(NextGenContext context)
            : base(context)
        {
            this._context = context;
        }

        /// <summary>
        /// Adds the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="AttachMore.NextGen.Core.Exceptions.APIExceptions.BadRequestException">The username is already in use</exception>
        public override void Add(User user)
        {
            var username = user.Email.Trim();

            if (GetQuery().Any(u => u.Email == username))
            {
                throw new BadRequestException("The username is already in use");
            }

            AddUserRoles(user, user.Roles);
            base.Add(user);
        }


        /// <summary>
        /// Adds the user roles.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleNames">The role names.</param>
        /// <exception cref="AttachMore.NextGen.Core.Exceptions.APIExceptions.NotFoundException"></exception>
        private void AddUserRoles(User user, IList<UserRole> roleNames)
        {
            user.Roles.Clear();

            foreach (var roleName in roleNames)
            {
                var role = _context.Query<Role>().FirstOrDefault(x => x.Name == roleName.Role.Name);

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
            var result = base.GetAll().Where(x => !x.IsDeleted)
                .Include(x => x.Roles)
                    .ThenInclude(x => x.Role);
            return result;
        }
    }
}
