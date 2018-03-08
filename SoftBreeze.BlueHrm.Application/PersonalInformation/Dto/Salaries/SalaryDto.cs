using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.Salaries
{
    public class SalaryDto:AuditedEntityDto
    {
        public long EmployeeId { get; set; }
        public int PayGradeId { get; set; }
        public int SalaryComponentId { get; set; }
        public int PayFrequencyId { get; set; }
        public int CurrencyId { get; set; }
        public double Amount { get; set; }
        public string Notes { get; set; }
    }

    public class GetSalaryInput
    {
        public int SalaryId { get; set; }
    }

    public class GetSalariesInput
    {
        public int EmployeeId { get; set; }
    }

    public class DeleteSalaryInput
    {
        public int SalaryId { get; set; }
    }
}
