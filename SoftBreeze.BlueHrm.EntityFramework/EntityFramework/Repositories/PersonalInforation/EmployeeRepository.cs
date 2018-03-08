using System.Linq;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{
    public interface IEmployeeRepository : IRepository<Employee, long>
    {
        Employee GetEmployeeByNumber(string employeeNumber);
    }


    public class EmployeeRepository : BlueHrmRepositoryBase<Employee, long>, IEmployeeRepository
    {
        public EmployeeRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }

        public Employee GetEmployeeByNumber(string employeeNumber)
        {
            return Table.FirstOrDefault(emp => emp.Number == employeeNumber);
        }
    }
}
