﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.Organisation.Dto.Locations
{
    public class DeleteLocationInput:IInputDto
    {
        [Required]
        public int LocationId { get; set; }
    }
}
