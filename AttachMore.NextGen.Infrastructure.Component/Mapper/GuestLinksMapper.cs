using AttachMore.NextGen.Core.DomainModels.GuestLink;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.GuestLink;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Component.Mapper
{
    /// <summary>
    /// Guest Link Mapper 
    /// </summary>
    public static class GuestLinksMapper<TSource, TDestination>
        where TSource : class
        where TDestination : class
    {
        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static TDestination Map(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });

            IMapper mapper = config.CreateMapper();

            var destination = mapper.Map<TSource, TDestination>(source);
            return destination;
        }

        /// <summary>
        /// Maps the request.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static GuestLinks MapRequest(GuestLinksModel model)
        {
            var request = new GuestLinks()
            {
                LinkName = model.LinkName == null ? null : model.LinkName,
                LinkUrl = model.LinkUrl == null ? null : model.LinkUrl,
                CreationDate = DateTime.UtcNow,
                //ExpirationDate = model.ExpirationDate == null ? null : model.ExpirationDate,
                GuestId = model.GuestId == null ? null : model.GuestId,
                //IsAllowAddRecipient = model.IsAllowAddRecipient,
                //NumberUsesAllowed = model.NumberUsesAllowed,
                Status = model.Status,
                //UploadedEmails = model.UploadedEmails == null ? null : model.UploadedEmails,
                //UploadLimit = model.UploadLimit,
                //UploadLimit = model.UploadLimit,
                UserId = model.UserId
            };
            return request;
        }

        /// <summary>
        /// Maps the response.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static List<TDestination> MapResponse(List<TSource> source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });

            IMapper mapper = config.CreateMapper();

            var destination = mapper.Map<List<TSource>, List<TDestination>>(source);
            return destination;
        }

    }
}
