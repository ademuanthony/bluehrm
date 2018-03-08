using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.People.Dto
{
    public class GetPeopleInput : IInputDto
    {
        public string Filter { get; set; }
    }
}