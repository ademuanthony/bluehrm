using Abp.Domain.Entities;

namespace SoftBreeze.BlueHrm.SystemConfiguration
{
    public class Currency:Entity
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
    }
}
