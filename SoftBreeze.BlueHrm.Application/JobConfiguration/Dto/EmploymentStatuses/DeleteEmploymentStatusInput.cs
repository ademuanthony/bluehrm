﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace BlueHrm.JobConfiguration.Dto
{
    public class DeleteEmploymentStatusInput:IInputDto
    {
        public int Id { get; set; }
    }
}
