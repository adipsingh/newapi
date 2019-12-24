using AttachMore.NextGen.Core.DomainModels.Package;
using AttachMore.NextGen.Core.IRepositories.Package;
using AttachMore.NextGen.Core.IServices.Package;
using AttachMore.NextGen.Infrastructure.Component.Mapper;
using AttachMore.NextGen.Infrastructure.DataAccess.Context;
using AttachMore.NextGen.Infrastructure.Repositories.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Services.Package
{
    /// <summary>
    /// User Package Service
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IServices.Package.IPackageService" />
    public class PackageService : IPackageService
    {
        /// <summary>
        /// The m package repository
        /// </summary>
        private readonly IPackageRepository m_PackageRepository;

        /// <summary>
        /// The m user package repository
        /// </summary>
        private readonly IUserPackageRepository m_UserPackageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageService"/> class.
        /// </summary>
        /// <param name="packageRepository">The package repository.</param>
        public PackageService(IPackageRepository packageRepository, IUserPackageRepository userPackageRepository)
        {
            this.m_PackageRepository = packageRepository;
            this.m_UserPackageRepository = userPackageRepository;
        }

        /// <summary>
        /// Gets all package.
        /// </summary>
        /// <returns></returns>
        public List<PackageModel> GetAllPackage()
        {
            PackageModel response = new PackageModel();
            UserPackageMapper mapper = new UserPackageMapper();
            var package = this.m_PackageRepository.GetAll().ToList();
            var destination = mapper.MapPackage(package);
            return destination;
        }

        /// <summary>
        /// Adds the user package.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool AddUserPackage(UserPackagesModel model)
        {
            try
            {
                UserPackageMapper mapper = new UserPackageMapper();
                model.CreatedDate = DateTime.Now;
                model.IsDeleted = false;
                var destination = mapper.MapUserPackage(model);
                this.m_UserPackageRepository.Add(destination);
                return true;
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }
    }
}
