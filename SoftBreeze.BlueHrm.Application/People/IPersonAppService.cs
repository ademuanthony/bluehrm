using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SoftBreeze.BlueHrm.People.Dto;

namespace SoftBreeze.BlueHrm.People
{
    public interface IPersonAppService : IApplicationService
    {
        ListResultOutput<PersonListDto> GetPeople(GetPeopleInput input);

        Task CreatePerson(CreatePersonInput input);

        Task DeletePerson(IdInput input);

        Task DeletePhone(IdInput<long> input);
 
        Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input);
    }
}
