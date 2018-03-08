using System.Collections.Generic;
using SoftBreeze.BlueHrm.Auditing.Dto;
using SoftBreeze.BlueHrm.Dto;

namespace SoftBreeze.BlueHrm.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
