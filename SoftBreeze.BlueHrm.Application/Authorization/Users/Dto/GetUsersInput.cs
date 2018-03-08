﻿using Abp.Runtime.Validation;
using SoftBreeze.BlueHrm.Dto;

namespace SoftBreeze.BlueHrm.Authorization.Users.Dto
{
    public class GetUsersInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Name,Surname";
            }
        }
    }
}