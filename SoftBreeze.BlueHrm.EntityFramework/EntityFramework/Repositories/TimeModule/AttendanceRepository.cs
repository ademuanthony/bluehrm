using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.TimeModule;
using Tony.Common.Infrastructure;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.TimeModule
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        IEnumerable<AttendanceDo> GetAttendanceDos(Expression<Func<Attendance, bool>> predicate = null);
        IEnumerable<AttendanceDo> GetAttendanceReport(DateTime date);
    }
    public class AttendanceRepository:BlueHrmRepositoryBase<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider)
        {

        }

        public IEnumerable<AttendanceDo> GetAttendanceDos(Expression<Func<Attendance, bool>> predicate = null)
        {
            return (predicate == null ? Table : Table.Where(predicate)).Select(at => new AttendanceDo
            {
                Id = at.Id,
                EmployeeId = at.EmployeeId,
                EmployeeName = at.Employee.FirstName + " " + at.Employee.LastName + " " + at.Employee.MiddleName,
                EmployeeNumber = at.Employee.Number,
                ClockIn = at.ClockIn,
                ClockOut = at.ClockOut,
                Date = at.Date
            });
        }

        public IEnumerable<AttendanceDo> GetAttendanceReport(DateTime date)
        {
            date = new TimeStamp(date, true).Date;
            return from employees in Context.Employees
                from attendances in
                    Context.Attendances.Where(at => at.EmployeeId == employees.Id && at.Date == date).DefaultIfEmpty()
                select new AttendanceDo
                {
                    EmployeeId = employees.Id,
                    EmployeeNumber = employees.Number,
                    EmployeeName = employees.FirstName + " " + employees.LastName + " " + employees.MiddleName,
                    ClockIn = attendances == null ? null : attendances.ClockIn,
                    Date = date,
                    ClockOut = attendances == null ? null : attendances.ClockOut,
                    Status = attendances == null ? "Absent" : "Present"

                };



        } 
    }
}
