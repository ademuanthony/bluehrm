using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.JobConfiguration.Dto.Jobs
{
    public class CreateJobInput:IInputDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public string Note { get; set; }
    }
}
