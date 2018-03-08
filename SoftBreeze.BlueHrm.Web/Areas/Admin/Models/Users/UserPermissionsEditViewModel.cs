using Abp.AutoMapper;
using SoftBreeze.BlueHrm.Authorization.Users;
using SoftBreeze.BlueHrm.Authorization.Users.Dto;
using SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.Common;

namespace SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}