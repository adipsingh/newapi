using AttachMore.NextGen.ServiceModel.Request;
using AttachMore.NextGen.ServiceModel.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.ServiceFactory
{
    public abstract class FactoryBase<TEntity, TRequest, TResponse> : IFactory<TEntity>
        where TEntity : class
        where TResponse : ResponseBase
        where TRequest : RequestBase
    {

        private TRequest m_Request;

        private JObject m_jObject;

        public TRequest RequestObject
        {
            get { return this.m_Request; }
            set { this.m_Request = value; }
        }

        public JObject jsonObject
        {
            set
            {
                this.m_jObject = value;
                if (this.m_jObject != null)
                {
                    m_Request = JsonConvert.DeserializeObject(this.m_jObject.ToString(), typeof(TRequest)) as TRequest;
                }
            }
        }



        public abstract TEntity MapRequest(params object[] parameters);

        public TEntity CreateRequest(params object[] parametes)
        {
            return this.MapRequest();
        }
    }
}
