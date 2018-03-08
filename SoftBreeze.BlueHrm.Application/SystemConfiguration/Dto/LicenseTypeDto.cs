using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.SystemConfiguration.Dto
{
    public class LicenseTypeDto:AuditedEntityDto 
    {
        public string Name { get; set; }
    }

    public class CreateOrEditLicenseTypeInput
    {
        public LicenseTypeDto LicenseType { get; set; }
    }

    public class DeleteLicenseTypeInput
    {
        public int LicenseTypeId { get; set; }
    }

    public class GetLicenseTypeInput
    {
        public int LicenseTypeId { get; set; }
    }
}
