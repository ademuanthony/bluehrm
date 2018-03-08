using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.LeaveModule.Dto
{
    public class GetLeaveDoInput:IInputDto
    {
        public int LeaveId { get; set; }
    }
}
