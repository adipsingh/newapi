using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Core.DomainModels.Dashboard
{
    public class DashboardUserDetailsModel
    {
        public string Name { get; set; }
        public string UserRole { get; set; }
        public int Status { get; set; }
        public DateTime NextBillingDate { get; set; }
        public DateTime Expires { get; set; }
    }
}
