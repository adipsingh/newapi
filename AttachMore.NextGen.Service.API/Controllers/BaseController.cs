using AttachMore.NextGen.Core.Framework.Attributes;
using AttachMore.NextGen.Core.IRepositories;
using AttachMore.NextGen.Core.IServices;
using AttachMore.NextGen.ServiceFactory;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Service.API.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public abstract class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        /// <summary>
        /// The m factory
        /// </summary>
        private IFactory<TEntity> m_Factory;

        /// <summary>
        /// Gets or sets the request object.
        /// </summary>
        /// <value>
        /// The request object.
        /// </value>
        public object RequestObject { get; set; }

        /// <summary>
        /// Gets the factory.
        /// </summary>
        /// <value>
        /// The factory.
        /// </value>
        public IFactory<TEntity> Factory
        {
            get
            {
                if (this.m_Factory == null)
                {
                    var factoryType = (FactoryAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(FactoryAttribute));
                    if (factoryType != null)
                    {
                        this.m_Factory = Activator.CreateInstance(factoryType.Type) as IFactory<TEntity>;
                        this.m_Factory.jsonObject = this.RequestObject == null ? null : this.RequestObject as JObject;
                    }
                }
                return m_Factory;
            }
        }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public IRepository<TEntity> Repository { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        public IBaseService<TEntity> Service { get; set; }
    }
}
