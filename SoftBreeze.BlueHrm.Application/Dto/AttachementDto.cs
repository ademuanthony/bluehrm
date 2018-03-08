using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.Dto
{
    public class AttachementDto:AuditedEntityDto
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Note { get; set; }
    }
}
