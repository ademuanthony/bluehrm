using Abp.AutoMapper;
using SoftBreeze.BlueHrm.Authorization.Roles.Dto;
using SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.Common;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode
        {
            get { return Role.Id.HasValue; }
        }

        public CreateOrEditRoleModalViewModel(GetRoleForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}