using AttachMore.NextGen.Core.DomainModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.IServices.Common
{
    /// <summary>
    /// Interface newsletter Service.
    /// </summary>
    public interface INewsLettersService
    {
        /// <summary>
        /// Adds the specified email.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        string Add(NewsLettersModel Email);
    }
}
