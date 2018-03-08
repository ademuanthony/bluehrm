using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace SoftBreeze.BlueHrm.People.Dto
{
    [AutoMapFrom(typeof(Phone))]
    public class PhoneInPersonListDto : CreationAuditedEntityDto<long>
    {
        public PhoneType Type { get; set; }

        public string Number { get; set; }
    }
}