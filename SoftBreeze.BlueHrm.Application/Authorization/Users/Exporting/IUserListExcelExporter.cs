using System.Collections.Generic;
using SoftBreeze.BlueHrm.Authorization.Users.Dto;
using SoftBreeze.BlueHrm.Dto;

namespace SoftBreeze.BlueHrm.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}