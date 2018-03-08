using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{

    public interface ISupervisorRepository : IRepository<Supervisor>
    {
        IEnumerable<SupervisorDo> GetSubOrdinates(long employeeId);
        IEnumerable<SupervisorDo> GetSupervisorDos(long employeeId);
    }


    public class SupervisorRepository : BlueHrmRepositoryBase<Supervisor>, ISupervisorRepository
    {
        public SupervisorRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }

        public IEnumerable<SupervisorDo> GetSupervisorDos(long employeeId)
        {
            return Table.Where(t => t.EmployeeId == employeeId).Select(s => new SupervisorDo
            {
                Name = s.SupervisingEmployee.FirstName + " " + s.SupervisingEmployee.LastName + " " + s.SupervisingEmployee.MiddleName,
                Id = s.Id,
                CreationTime = s.CreationTime
            });
        }

        public IEnumerable<SupervisorDo> GetSubOrdinates(long employeeId)
        {
            return Table.Where(t => t.SupervisorId == employeeId).Select(s => new SupervisorDo
            {
                Name = s.Employee.FirstName + " " + s.Employee.LastName + " " + s.Employee.MiddleName,
                Id = s.Id,
                CreationTime = s.CreationTime
            });
        }
        
    }
}
