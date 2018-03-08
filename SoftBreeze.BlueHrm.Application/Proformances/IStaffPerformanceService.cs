using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SoftBreeze.BlueHrm.Dto;
using SoftBreeze.BlueHrm.Performance;
using SoftBreeze.BlueHrm.Proformances.Dto;

namespace SoftBreeze.BlueHrm.Proformances
{
    public interface IStaffPerformanceService:IApplicationService
    {
        OutputBase SaveKeyResultAreaAttribute(SaveKeyResultAreaAttributeInput input);
        OutputBase DeleteKeyResultAreaAttribute(DeleteKeyResultAreaAttributeInput input);
        PerformacneIndicatorDto GetKeyResultAreaAttribute(GetKeyResultAreaAttributeInput input);
        ListResultOutput<PerformacneIndicatorDto> GetKeyResultAreaAttributes();
        ListResultOutput<PerfomanceEvaluationStatusDo> GetPerfomanceEvaluationStatusDos(GetPerfomanceEvaluationStatusDosInput input);
        ListResultOutput<PerformanceEvaluationPeriodDto> GetPerformanceEvaluationPeriods();
        PerformanceEvaluationPeriodDto GetPerformanceEvaluationPeriod(GetPerformanceEvaluationPeriodInput input);

        StaffPerformanceDto GetPerformance(long employeeId, int periodId, bool createNewIfNon = false);

        OutputBase SaveKra(SaveKraInput input);
        ListResultOutput<KeyResultAreaDo> GetKras(GetKrasInput input);
        KeyResultAreaDto GetKeyResultArea(GetKraInput input);
    }
}
