using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Immigrations;

namespace SoftBreeze.BlueHrm.Web.Areas.Pim.Models
{
    public class CreateOrEditImmigrationModel
    {
        public CreateOrEditImmigrationModel(ImmigrationDto input, bool isNew)
        {
            IsEditMode = !isNew;
            Immigration = input;
        }

        public bool IsEditMode { get; set; }

        public ImmigrationDto Immigration { get; set; }
    }
}