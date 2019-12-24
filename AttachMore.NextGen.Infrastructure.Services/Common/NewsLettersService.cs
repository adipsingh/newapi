using AttachMore.NextGen.Core.DomainModels.Common;
using AttachMore.NextGen.Core.IRepositories.Common;
using AttachMore.NextGen.Core.IServices.Common;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Services.Common
{
    /// <summary>
    /// NewsLetters Service
    /// </summary>
    /// <seealso cref="AttachMore.NextGen.Core.IServices.Common.INewsLettersService" />
    public class NewsLettersService : INewsLettersService
    {
        /// <summary>
        /// The m news letters repository
        /// </summary>
        private readonly INewsLettersRepository m_NewsLettersRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsLettersService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public NewsLettersService(INewsLettersRepository repository)
        {
            this.m_NewsLettersRepository = repository;
        }

        /// <summary>
        /// Adds the specified email.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string Add(NewsLettersModel Model)
        {
            try
            {
                string message = string.Empty;
                var checkEmail = this.m_NewsLettersRepository.GetAll().Where(a => a.Email == Model.Email).FirstOrDefault();
                if (checkEmail == null)
                {
                    NewsLetters newsLetters = new NewsLetters();
                    newsLetters.Email = Model.Email;
                    newsLetters.CreatedDate = DateTime.Now;
                    this.m_NewsLettersRepository.Add(newsLetters);
                    return "true";
                }
                return message = "Email is already Exist";

            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }
    }
}
