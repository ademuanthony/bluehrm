using System.Threading.Tasks;
using Abp.Application.Services;
using SoftBreeze.BlueHrm.Authorization.Users.Profile.Dto;

namespace SoftBreeze.BlueHrm.Authorization.Users.Profile
{
    public interface IProfileAppService : IApplicationService
    {
        Task<CurrentUserProfileEditDto> GetCurrentUserProfileForEdit();

        Task UpdateCurrentUserProfile(CurrentUserProfileEditDto input);
        
        Task ChangePassword(ChangePasswordInput input);
    }
}
