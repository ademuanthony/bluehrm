using Abp.AutoMapper;
using SoftBreeze.BlueHrm.Authorization.Users;
using SoftBreeze.BlueHrm.Authorization.Users.Profile.Dto;

namespace SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.Profile
{
    [AutoMapFrom(typeof (CurrentUserProfileEditDto))]
    public class MySettingsViewModel : CurrentUserProfileEditDto
    {
        public bool CanChangeUserName
        {
            get { return UserName != User.AdminUserName; }
        }

        public MySettingsViewModel(CurrentUserProfileEditDto currentUserProfileEditDto)
        {
            currentUserProfileEditDto.MapTo(this);
        }
    }
}