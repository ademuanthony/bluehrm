using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class SalaryViewDo:AuditedEntityDto
    {
        public long EmployeeId { get; set; }
        public string PayGrade { get; set; }
        public string SalaryComponent { get; set; }
        public string PayFrequency { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
        public string Notes { get; set; }
    }
}
