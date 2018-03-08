using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.JobTerminationReasons;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Models.JobConfiguration
{
    public class CreateOrEditJobTerminationReasonViewModel
    {
        public CreateOrEditJobTerminationReasonViewModel(JobTerminationReasonDto input)
        {
            JobTerminationReason = input;
        }
        public JobTerminationReasonDto JobTerminationReason { get; set; }

        public bool IsEditMode { get { return !JobTerminationReason.Name.IsNullOrEmpty(); } }
    }
}