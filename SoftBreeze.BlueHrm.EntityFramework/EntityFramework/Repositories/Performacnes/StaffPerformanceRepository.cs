using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.Performance;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.Performacnes
{
    public interface IStaffPerformanceRepository : IRepository<StaffPerformance>
    {
        IEnumerable<PerfomanceEvaluationStatusDo> GetPerfomanceEvaluationStatusDos(int periodId);
    }

    public class StaffPerformanceRepository:BlueHrmRepositoryBase<StaffPerformance>, IStaffPerformanceRepository
    {
        public StaffPerformanceRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider)
        {

        }

        public IEnumerable<PerfomanceEvaluationStatusDo> GetPerfomanceEvaluationStatusDos(int periodId)
        {
            return from employee in Context.Employees
                from performance in
                    Table.Where(p => p.EmployeeId == employee.Id && p.PeriodId == periodId).DefaultIfEmpty()
                select new PerfomanceEvaluationStatusDo
                {
                    StartDate = performance != null ? performance.CreationTime : DateTime.MinValue,
                    EmployeeNumber = employee.Number,
                    EmployeeName = employee.FirstName + " " + employee.LastName + " " + employee.MiddleName,
                    Status = performance != null ? performance.Status : PerformanceEvaluationStatus.NotStarted
                };
        }
    }
}
