﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.JobConfiguration.Dto.JobCategories
{
    public class CreateJobCategoryInput:IInputDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
