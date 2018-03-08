using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.JobCategories;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Models.JobConfiguration
{
    public class CreateOrEditJobCategoryViewModel
    {
        public CreateOrEditJobCategoryViewModel(JobCategoryDto jobCategory)
        {
            JobCategory = jobCategory;
        }
        public bool IsEditMode { get { return !JobCategory.Name.IsNullOrEmpty(); } }

        public JobCategoryDto JobCategory { get; set; }
    }
}