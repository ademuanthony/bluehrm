using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Salaries;

namespace SoftBreeze.BlueHrm.Web.Areas.Pim.Models
{
    public class CreateOrEditSalaryModel
    {
        public CreateOrEditSalaryModel(SalaryDto input, bool isNew)
        {
            IsEditMode = !isNew;
            Salary = input;
        }

        public bool IsEditMode { get; set; }

        public SalaryDto Salary { get; set; }
    }
}