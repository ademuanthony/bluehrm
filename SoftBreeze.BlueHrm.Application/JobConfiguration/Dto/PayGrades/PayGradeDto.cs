using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.JobConfiguration.Dto.PayGrades
{
    public class PayGradeDto:AuditedEntityDto
    {
        public string Name { get; set; }
    }
}
