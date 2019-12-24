using AttachMore.NextGen.Core.IRepositories.Common;
using AttachMore.NextGen.Infrastructure.DataAccess.Context;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Repositories.Common
{
    /// <summary>
    /// NewLetters Repository
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Infrastructure.Repositories.Repository{AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Common.NewsLetters, AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    /// <seealso cref="AttachMore.NextGen.Core.IRepositories.Common.INewsLettersRepository" />
    public class NewsLettersRepository : Repository<NewsLetters, NextGenContext>, INewsLettersRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewsLettersRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NewsLettersRepository(NextGenContext context)
            : base(context)
        {
        }
    }
}
