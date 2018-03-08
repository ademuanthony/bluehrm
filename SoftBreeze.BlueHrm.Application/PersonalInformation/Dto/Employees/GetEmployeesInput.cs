using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Runtime.Validation;
using SoftBreeze.BlueHrm.Dto;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.Employees
{
    public class GetEmployeesInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "FirstName,LastName";
            }
        }
    }
}
