using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using Castle.MicroKernel.Registration.Interceptor;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{
    public interface ISalaryRepository : IRepository<Salary>
    {
        IEnumerable<SalaryViewDo> GetSalaryViewDos(long employeeId);
    }


    public class SalaryRepository : BlueHrmRepositoryBase<Salary>, ISalaryRepository
    {
        public SalaryRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }

        public IEnumerable<SalaryViewDo> GetSalaryViewDos(long employeeId)
        {
            return Table.Where(s => s.EmployeeId == employeeId).Select(s => new SalaryViewDo
            {
                Id = s.Id,
                Amount = s.Amount,
                CreationTime = s.CreationTime,
                CreatorUserId = s.CreatorUserId,
                Currency = s.Currency.Code,
                EmployeeId = s.EmployeeId,
                PayGrade = s.PayGrade.Name,
                SalaryComponent = s.Component.Name,
                LastModificationTime = s.LastModificationTime,
                LastModifierUserId = s.LastModifierUserId,
                Notes = s.Notes,
                PayFrequency = s.PayFrequency.Name
            });
        }
    }

}
