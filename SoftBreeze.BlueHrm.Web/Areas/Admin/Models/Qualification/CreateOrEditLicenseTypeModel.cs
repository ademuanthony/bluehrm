using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using SoftBreeze.BlueHrm.SystemConfiguration.Dto;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Models.Qualification
{
    public class CreateOrEditLicenseTypeModel
    {
        public CreateOrEditLicenseTypeModel(LicenseTypeDto licenseType)
        {
            LicenseType = licenseType;
        }
        public LicenseTypeDto LicenseType { get; set; }

        public bool IsEditMode { get { return !LicenseType.Name.IsNullOrEmpty(); } }
    }
}