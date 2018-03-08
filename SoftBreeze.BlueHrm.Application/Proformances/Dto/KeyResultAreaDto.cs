using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.Proformances.Dto
{
    public class KeyResultAreaDto:AuditedEntityDto
    {
        public int PerformanceId { get; set; }
        public int AttributeId { get; set; }
        public int? Rating { get; set; }
        public string ActualAcheivement { get; set; }
        public string Comment { get; set; }

        public PerformacneIndicatorDto Indicator { get; set; }
    }

    public class SaveKraInput : IInputDto
    {
        public KeyResultAreaDto Kra { get; set; }
    }
    
    public class GetKraInput
    {
        public int KraId { get; set; } 
    }

    public class GetKrasInput
    {
        public int PerformanceId { get; set; }
    }
    public class DeleteKraInput
    {
        public int KraId { get; set; }
    }
}
