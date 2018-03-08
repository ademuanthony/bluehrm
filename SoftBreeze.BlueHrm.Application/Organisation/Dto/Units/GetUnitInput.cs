using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.Organisation.Dto.Units
{
    public class GetUnitInput:IInputDto
    {
        public int UnitId { get; set; }
    }
}
