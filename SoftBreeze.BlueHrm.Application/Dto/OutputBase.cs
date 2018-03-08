using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.Dto
{
    public class OutputBase:IOutputDto
    {
        public long? Id { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
