using AttachMore.NextGen.Core.DomainModels.Package;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Packages;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Component.Mapper
{
    /// <summary>
    /// UserPackage Mapper 
    /// </summary>
    public class UserPackageMapper
    {
        /// <summary>
        /// Maps the package.
        /// </summary>
        /// <returns></returns>
        public List<PackageModel> MapPackage(List<Package> source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Package, PackageModel>();
            });

            IMapper mapper = config.CreateMapper();

            var destination = mapper.Map<List<Package>, List<PackageModel>>(source);
            return destination;
        }

        public UserPackages MapUserPackage(UserPackagesModel source)
        {
            //UserPackages Entity = new UserPackages();
            //Entity.UserId = source.UserId;
            //Entity.PackageId = source.PackageId;
            //Entity.IsDeleted = source.IsDeleted;
            //Entity.CreatedDate = source.CreatedDate;
            //Entity.UpdatedDate = source.UpdatedDate;
            //return Entity;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserPackagesModel, UserPackages>();
            });

            IMapper mapper = config.CreateMapper();

            var destination = mapper.Map<UserPackagesModel, UserPackages>(source);
            return destination;
        }
    }
}
