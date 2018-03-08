using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AutoMapper;
using Castle.Core.Internal;
using SoftBreeze.BlueHrm.Dto;
using SoftBreeze.BlueHrm.EntityFramework.Repositories.Performacnes;
using SoftBreeze.BlueHrm.Performance;
using SoftBreeze.BlueHrm.Proformances.Dto;

namespace SoftBreeze.BlueHrm.Proformances
{
    public class StaffPerformanceService : BlueHrmServiceBase, IStaffPerformanceService
    {
        private readonly IPerformanceIndicatorRepository _performanceIndicatorRepository;
        private readonly IStaffPerformanceRepository _staffPerformanceRepository;
        private readonly IPerformanceEvaluationPeriodRepository _performanceEvaluationPeriodRepository;
        private readonly IKeyResultAreaRepository _keyResultAreaRepository;

        public StaffPerformanceService(IPerformanceIndicatorRepository performanceIndicatorRepository,
            IStaffPerformanceRepository staffPerformanceRepository,
            IPerformanceEvaluationPeriodRepository performanceEvaluationPeriodRepository,
            IKeyResultAreaRepository keyResultAreaRepository)
        {
            _performanceIndicatorRepository = performanceIndicatorRepository;
            _staffPerformanceRepository = staffPerformanceRepository;
            _performanceEvaluationPeriodRepository = performanceEvaluationPeriodRepository;
            _keyResultAreaRepository = keyResultAreaRepository;
        }

        #region//indicator
        public OutputBase SaveKeyResultAreaAttribute(SaveKeyResultAreaAttributeInput input)
        {
            if (_performanceIndicatorRepository.Query(q => q.Any(att => att.Name == input.Attribute.Name)))
            {
                return new OutputBase { Message = "An attribute with the same name already exists", Success = false };
            }
            _performanceIndicatorRepository.InsertOrUpdate(Mapper.Map<PerformanceIndicator>(input.Attribute));
            return new OutputBase { Message = "Saved successfully", Success = true };
        }

        public OutputBase DeleteKeyResultAreaAttribute(DeleteKeyResultAreaAttributeInput input)
        {
            _performanceIndicatorRepository.Delete(input.AttributeId);
            return new OutputBase { Message = "Attribute deleted", Success = true };
        }

        public PerformacneIndicatorDto GetKeyResultAreaAttribute(GetKeyResultAreaAttributeInput input)
        {
            return Mapper.Map<PerformacneIndicatorDto>(_performanceIndicatorRepository.Get(input.AttributeId));
        }

        public ListResultOutput<PerformacneIndicatorDto> GetKeyResultAreaAttributes()
        {
            try
            {
                return
                               new ListResultOutput<PerformacneIndicatorDto>(
                                   Mapper.Map<List<PerformacneIndicatorDto>>(_performanceIndicatorRepository.GetAllList()));
            }
            catch (Exception exception)
            {
                //ignored
                return new ListResultOutput<PerformacneIndicatorDto>();
            }

        }
        #endregion

        //Evaluation Status
        public ListResultOutput<PerfomanceEvaluationStatusDo> GetPerfomanceEvaluationStatusDos(
            GetPerfomanceEvaluationStatusDosInput input)
        {
            var items = _staffPerformanceRepository.GetPerfomanceEvaluationStatusDos(input.PeriodId).ToList();
            if (!string.IsNullOrEmpty(input.EmployeeNumber))
                items = items.Where(it => it.EmployeeNumber == input.EmployeeNumber).ToList();
            items.ForEach(item =>
            {
                if (item.StartDate == DateTime.MinValue) item.StartDate = null;
            });
            return new ListResultOutput<PerfomanceEvaluationStatusDo>(
                items);
        }

        //Periods
        public ListResultOutput<PerformanceEvaluationPeriodDto> GetPerformanceEvaluationPeriods()
        {
            return
                new ListResultOutput<PerformanceEvaluationPeriodDto>(
                    Mapper.Map<List<PerformanceEvaluationPeriodDto>>(_performanceEvaluationPeriodRepository.GetAllList()));
        }

        public PerformanceEvaluationPeriodDto GetPerformanceEvaluationPeriod(GetPerformanceEvaluationPeriodInput input)
        {
            return Mapper.Map<PerformanceEvaluationPeriodDto>(_performanceEvaluationPeriodRepository.Get(input.PeriodId));
        }

        //performance
        public StaffPerformanceDto GetPerformance(long employeeId, int periodId, bool createNewIfNon = false)
        {
            if (!createNewIfNon ||
                _staffPerformanceRepository.Query(q => q.Any(p => p.EmployeeId == employeeId && p.PeriodId == periodId)))
                return
                    Mapper.Map<StaffPerformanceDto>(
                        _staffPerformanceRepository.FirstOrDefault(p => p.EmployeeId == employeeId &&
                                                                        p.PeriodId == periodId));
            var id = _staffPerformanceRepository.InsertAndGetId(new StaffPerformance
            {
                EmployeeId = employeeId,
                PeriodId = periodId
            });
            var indicators = GetKeyResultAreaAttributes().Items;
            indicators.ForEach(indicator =>
            {
                _keyResultAreaRepository.Insert(new KeyResultArea {PerformanceId = id, AttributeId = indicator.Id});
            });

            return
                Mapper.Map<StaffPerformanceDto>(
                    _staffPerformanceRepository.FirstOrDefault(p => p.EmployeeId == employeeId &&
                                                                    p.PeriodId == periodId));
        }

        #region KRA

        public OutputBase SaveKra(SaveKraInput input)
        {
            if (
                _keyResultAreaRepository.Query(
                    q =>
                        q.Any(
                            kra =>
                                kra.PerformanceId == input.Kra.PerformanceId && kra.AttributeId == input.Kra.AttributeId
                                && kra.Id != input.Kra.Id)))
            {
                return new OutputBase
                {
                    Message = "You have already made an entry for the selected performance indicator",
                    Success = false
                };
            }

            _keyResultAreaRepository.InsertOrUpdate(Mapper.Map<KeyResultArea>(input.Kra));
            return new OutputBase {Message = "Saved successfully", Success = true};
        }

        public ListResultOutput<KeyResultAreaDo> GetKras(GetKrasInput input)
        {
            return new ListResultOutput<KeyResultAreaDo>(_keyResultAreaRepository.GetResultAreaDos(input.PerformanceId).ToList());
        }

        public KeyResultAreaDto GetKeyResultArea(GetKraInput input)
        {
            return Mapper.Map<KeyResultAreaDto>(_keyResultAreaRepository.FirstOrDefault(k => k.Id == input.KraId));
        }
        #endregion
    }
}
