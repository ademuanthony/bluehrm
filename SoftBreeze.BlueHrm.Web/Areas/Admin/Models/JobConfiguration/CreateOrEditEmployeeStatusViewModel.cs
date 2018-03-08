using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlueHrm.JobConfiguration.Dto;
using Castle.Core.Internal;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.EmploymentStatuses;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.Jobs;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Models.JobConfiguration
{
    public class CreateOrEditEmployeeStatusViewModel
    {
        public CreateOrEditEmployeeStatusViewModel(EmploymentStatusDto employmentStatus)
        {
            EmploymentStatus = employmentStatus;
        }
        public bool IsEditMode { get { return !EmploymentStatus.Name.IsNullOrEmpty(); } }

        public EmploymentStatusDto EmploymentStatus { get; set; }
    }
}