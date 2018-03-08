using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.SystemConfiguration.Dto
{
    public class CountryDto:EntityDto
    {
        public string Iso { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Iso3 { get; set; }
        public string NumberCode { get; set; }
        public string PhoneCode { get; set; }
    }

    public class GetCountryInput
    {
        public int CountryId { get; set; }
    }
}
