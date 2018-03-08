using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.Jobs;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Models.JobConfiguration
{
    public class CreateOrEditJobViewModel
    {
        public CreateOrEditJobViewModel(JobDto job)
        {
            Job = job;
        }
        public bool IsEditMode { get { return !Job.Title.IsNullOrEmpty(); } }

        public JobDto Job { get; set; }
    }
}