using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.Proformances.Dto
{
    public class PerformacneIndicatorDto:AuditedEntityDto
    {
        public string Name { get; set; }
    }

    public class SaveKeyResultAreaAttributeInput : IInputDto
    {
        public PerformacneIndicatorDto Attribute { get; set; }
    }

    public class DeleteKeyResultAreaAttributeInput : IInputDto
    {
        public int AttributeId { get; set; }
    }

    public class GetKeyResultAreaAttributeInput : IInputDto
    {
        public int AttributeId { get; set; }
    }

    public class GetPerfomanceEvaluationStatusDosInput : IInputDto
    {
        public int PeriodId { get; set; }
        public string EmployeeNumber { get; set; }
    }
}
