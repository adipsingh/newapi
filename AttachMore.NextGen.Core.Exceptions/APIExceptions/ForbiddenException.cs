using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.Exceptions.APIExceptions
{
    /// <summary>
    /// Forbidden Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ForbiddenException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ForbiddenException(string message) : base(message)
        {
        }
    }
}
