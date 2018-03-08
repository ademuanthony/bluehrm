using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using SoftBreeze.BlueHrm.SystemConfiguration.Dto;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Models.Qualification
{
    public class CreateOrEditEducationalLevelModel
    {
        public CreateOrEditEducationalLevelModel(EducationLevelDto level)
        {
            EducationLevel = level;
        }
        public EducationLevelDto EducationLevel { get; set; }
        public bool IsEditMode { get { return !EducationLevel.Name.IsNullOrEmpty(); } }
    }
}