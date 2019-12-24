using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.ServiceFactory
{
    public interface IFactory<TEntity> where TEntity : class
    {
        JObject jsonObject { set; }

        TEntity CreateRequest(params object[] parametes);

    }
}
