using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.JobConfiguration.Dto.Jobs
{
    public class JobDto:EntityDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public string Note { get; set; }
    }
}
