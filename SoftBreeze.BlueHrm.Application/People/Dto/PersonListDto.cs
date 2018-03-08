using System.Collections.ObjectModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace SoftBreeze.BlueHrm.People.Dto
{
    [AutoMapFrom(typeof(Person))]
    public class PersonListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public Collection<PhoneInPersonListDto> Phones { get; set; }
    }
}