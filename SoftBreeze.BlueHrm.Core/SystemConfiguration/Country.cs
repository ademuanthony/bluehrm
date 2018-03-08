using Abp.Domain.Entities;

namespace SoftBreeze.BlueHrm.SystemConfiguration
{
    public class Country:Entity
    {

        public string Iso { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Iso3 { get; set; }
        public string NumberCode { get; set; }
        public string PhoneCode { get; set; }
        
    }
}
