using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.JobConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration.Payrol;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class Salary:AuditedEntity
    {
        public long EmployeeId { get; set; }
        public int PayGradeId { get; set; } 
        public int SalaryComponentId { get; set; }
        public int PayFrequencyId { get; set; }
        public int CurrencyId { get; set; }
        public double Amount { get; set; }
        public string Notes { get; set; }


        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [ForeignKey("PayGradeId")]
        public PayGrade PayGrade { get; set; }

        [ForeignKey("SalaryComponentId")]
        public SalaryComponent Component { get; set; }

        [ForeignKey("PayFrequencyId")]
        public SalaryPayFrequency PayFrequency { get; set; }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }

    }
}
