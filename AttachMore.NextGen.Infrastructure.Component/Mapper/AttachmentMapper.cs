using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Component.Mapper
{
    public static class AttachmentMapper<TSoruce, TDestination>
        where TSoruce : class
        where TDestination : class
    {
        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static TDestination Map(TSoruce source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSoruce, TDestination>();
            });

            IMapper mapper = config.CreateMapper();

            var destination = mapper.Map<TSoruce, TDestination>(source);
            return destination;
        }

        /// <summary>
        /// Maps the list.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static List<TDestination> MapList(List<TSoruce> source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSoruce, TDestination>();
            });

            IMapper mapper = config.CreateMapper();

            var destination = mapper.Map<List<TSoruce>, List<TDestination>>(source);
            return destination;
        }
    }
}
