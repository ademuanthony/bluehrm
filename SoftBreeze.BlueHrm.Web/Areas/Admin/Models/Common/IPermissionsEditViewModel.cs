using System.Collections.Generic;
using SoftBreeze.BlueHrm.Authorization.Dto;

namespace SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}