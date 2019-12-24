using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.DataAccess.Context
{
    /// <summary>
    /// NextGenDBInitializer.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DropCreateDatabaseIfModelChanges{AttachMore.NextGen.Infrastructure.DataAccess.Context.NextGenContext}" />
    public class NextGenDBInitializer : DropCreateDatabaseIfModelChanges<NextGenContext>
    {
        /// <summary>
        /// A method that should be overridden to actually add data to the context for seeding.
        /// The default implementation does nothing.
        /// </summary>
        /// <param name="context">The context to seed.</param>
        protected override void Seed(NextGenContext context)
        {
            base.Seed(context);
        }
    }
}
