using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Educations;

namespace SoftBreeze.BlueHrm.Web.Areas.Pim.Models
{
    public class CreateOrEditQualificationModel
    {
        public CreateOrEditQualificationModel(EducationDto input, bool isNew)
        {
            IsEditMode = !isNew;
            Education = input;
        }

        public bool IsEditMode { get; set; }

        public EducationDto Education { get; set; }
    }
}