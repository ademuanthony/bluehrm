using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using SoftBreeze.BlueHrm.Dto;

namespace SoftBreeze.BlueHrm.TimeModule.Dto
{
    public class AttendanceDto:AuditedEntityDto
    {
        public long EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }
    }

    public class SaveAttendanceInput : IInputDto
    {
        public int? Id { get; set; }
        public string EmployeeNumber { get; set; }

        public DateTime Date { get; set; }
        public int HourIn { get; set; }
        public int MuniteIn { get; set; }
        public int? HourOut { get; set; }
        public int? MuniteOut { get; set; }

        public bool IsEditMode { get { return Id != null && Id != 0; } }
    }

    public class ClockInInput
    {
        
    }

    public class ClockoutInput
    {
        
    }

    public class DeleteAttanceInput : IInputDto
    {
        public int AttendanceId { get; set; }
    }

    public class GetAttendanceDtosInput:PagedAndSortedInputDto, IShouldNormalize
    {
        public string EmployeeNumber { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Date";
            }
        }
    }

    public class GetAttendanceReportsInput : IInputDto
    {
        public DateTime Date { get; set; }
    }
    public class GetAttendanceDtoInput
    {
        public int AttendanceId { get; set; }
    }

}
