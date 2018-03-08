using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Supervisor;

namespace SoftBreeze.BlueHrm.Web.Areas.Pim.Models
{
    public class CreateOrEditSupervisorModel
    {
        public CreateOrEditSupervisorModel(SupervisorDto input, bool isNew)
        {
            IsEditMode = !isNew;
            Supervisor = input;
        }

        public bool IsEditMode { get; set; }

        public SupervisorDto Supervisor { get; set; }
    }
}