﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.JobConfiguration.Dto.PayGrades
{
    public class DeletePayGradeInput:IInputDto
    {
        [Required]
        public int PayGradeId { get; set; }
    }
}