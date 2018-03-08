using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace BlueHrm.SystemConfiguration
{
    public class Membership:AuditedEntity
    {
        public string Name { get; set; }
    }
}
