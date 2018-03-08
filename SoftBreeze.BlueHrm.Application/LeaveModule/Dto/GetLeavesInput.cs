using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using SoftBreeze.BlueHrm.Dto;

namespace SoftBreeze.BlueHrm.LeaveModule.Dto
{
    public class GetLeavesInput: PagedAndSortedInputDto, IShouldNormalize
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public LeaveStatus Status { get; set; }
        public string EmployeeNumber { get; set; }
        public int? SubunitId { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "StartDate";
            }
        }
    }
}
