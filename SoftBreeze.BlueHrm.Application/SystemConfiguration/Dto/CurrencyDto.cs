using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.SystemConfiguration.Dto
{
    public class CurrencyDto:EntityDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
    }

    public class GetCurrencyInput
    {
        public int CurrencyId { get; set; }
    }
}
