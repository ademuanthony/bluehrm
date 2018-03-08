using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Dependants;

namespace SoftBreeze.BlueHrm.Web.Areas.Pim.Models
{
    public class CreateOrEditDependantModel
    {
        public CreateOrEditDependantModel(DependantDto input, bool isNew)
        {
            IsEditMode = !isNew;
            Dependant = input;
        }

        public bool IsEditMode { get; set; }

        public DependantDto Dependant { get; set; }
    }
}