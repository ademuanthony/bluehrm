using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.Employees
{
    public class GetEmployeeByNumberInput:IInputDto
    {
        public string Number { get; set; }
    }
}
