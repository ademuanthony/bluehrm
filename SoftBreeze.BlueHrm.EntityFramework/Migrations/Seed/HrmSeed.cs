using System.Linq;
using SoftBreeze.BlueHrm.EntityFramework;
using SoftBreeze.BlueHrm.LeaveModule;
using SoftBreeze.BlueHrm.Performance;
using SoftBreeze.BlueHrm.SystemConfiguration.Payrol;
using Tony.Common.Infrastructure;

namespace SoftBreeze.BlueHrm.Migrations.Seed
{
    public class HrmSeed
    {
        private readonly BlueHrmDbContext _context;

        public HrmSeed(BlueHrmDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreatePayFrequencies();
            CreateSalryComponents();
            CreateLeavePeriods();
            CreateEvaluationPeriods();
            CreatePerformanceIndicators();
        }

        private void CreateSalryComponents()
        {
            var basicSalary = _context.SalaryComponents.FirstOrDefault(s => s.Name == "Basic Salary");
            if (basicSalary == null)
            {
                _context.SalaryComponents.Add(new SalaryComponent { Name = "Basic Salary" });
            }

            var transpont = _context.SalaryComponents.FirstOrDefault(s => s.Name == "Transport Allawance");
            if (transpont == null)
            {
                _context.SalaryComponents.Add(new SalaryComponent { Name = "Transport Allawance" });
            }


            var house = _context.SalaryComponents.FirstOrDefault(s => s.Name == "House Allawance");
            if (house == null)
            {
                _context.SalaryComponents.Add(new SalaryComponent { Name = "House Allawance" });
            }

            var health = _context.SalaryComponents.FirstOrDefault(s => s.Name == "Health Allawance");
            if (health == null)
            {
                _context.SalaryComponents.Add(new SalaryComponent { Name = "Health Allawance" });
            }
        }

        private void CreatePayFrequencies()
        {
            var houly = _context.SalaryPayFrequencies.FirstOrDefault(p => p.Name == "Hourly");
            if (houly == null)
                _context.SalaryPayFrequencies.Add(new SalaryPayFrequency { Name = "Hourly" });

            var daily = _context.SalaryPayFrequencies.FirstOrDefault(p => p.Name == "Daily");
            if (daily == null)
                _context.SalaryPayFrequencies.Add(new SalaryPayFrequency { Name = "Daily" });

            var weekly = _context.SalaryPayFrequencies.FirstOrDefault(p => p.Name == "Weekly");
            if (weekly == null)
                _context.SalaryPayFrequencies.Add(new SalaryPayFrequency { Name = "Weekly" });

            var biWeekly = _context.SalaryPayFrequencies.FirstOrDefault(p => p.Name == "Bi Weekly");
            if (biWeekly == null)
                _context.SalaryPayFrequencies.Add(new SalaryPayFrequency { Name = "Bi Weekly" });

            var monthly = _context.SalaryPayFrequencies.FirstOrDefault(p => p.Name == "Monthly");
            if (monthly == null)
                _context.SalaryPayFrequencies.Add(new SalaryPayFrequency { Name = "Monthly" });

            var monthly1StDay = _context.SalaryPayFrequencies.FirstOrDefault(p => p.Name == "Monthly on First day on the Month");
            if (monthly1StDay == null)
                _context.SalaryPayFrequencies.Add(new SalaryPayFrequency { Name = "Monthly on First day on the Month" });
        }

        private void CreateLeavePeriods()
        {
            var startDate = TimeStamp.ThisYear.Date;
            var endDate = TimeStamp.NextYear.Date.AddDays(-1);
            var period = _context.LeavePeriods.FirstOrDefault(p => p.StatDate >= startDate && p.EndDate <= endDate);
            if (period == null)
            {
                _context.LeavePeriods.Add(new LeavePeriod {StatDate = startDate, EndDate = endDate});
            }

            for (var i = 1; i <= 9; i++)
            {
                startDate = startDate.AddYears(1);
                endDate = endDate.AddYears(1);
                period = _context.LeavePeriods.FirstOrDefault(p => p.StatDate >= startDate && p.EndDate <= endDate);
                if (period == null)
                    _context.LeavePeriods.Add(new LeavePeriod {StatDate = startDate, EndDate = endDate});
            }
        }

        private void CreateEvaluationPeriods()
        {
            var startDate = TimeStamp.ThisYear.Date;
            var endDate = TimeStamp.NextYear.Date.AddDays(-1);
            var period = _context.PerformanceEvaluationPeriods.FirstOrDefault(p => p.StartDate >= startDate && p.EndDate <= endDate);
            if (period == null)
            {
                _context.PerformanceEvaluationPeriods.Add(new PerformanceEvaluationPeriod { StartDate = startDate, EndDate = endDate });
            }

            for (var i = 1; i <= 9; i++)
            {
                startDate = startDate.AddYears(1);
                endDate = endDate.AddYears(1);
                period = _context.PerformanceEvaluationPeriods.FirstOrDefault(p => p.StartDate >= startDate && p.EndDate <= endDate);
                if (period == null)
                    _context.PerformanceEvaluationPeriods.Add(new PerformanceEvaluationPeriod { StartDate = startDate, EndDate = endDate });
            }
        }

        private void CreatePerformanceIndicators()
        {
            if (_context.PerformanceIndicators.FirstOrDefault(i => i.Name == "Job performance") == null)
            {
                _context.PerformanceIndicators.Add(new PerformanceIndicator { Name = "Job performance" });
            }

            if (_context.PerformanceIndicators.FirstOrDefault(i => i.Name == "Meets job expectations") == null)
            {
                _context.PerformanceIndicators.Add(new PerformanceIndicator { Name = "Meets job expectations" });
            }

            if (_context.PerformanceIndicators.FirstOrDefault(i => i.Name == "Partially meets job expectations") == null)
            {
                _context.PerformanceIndicators.Add(new PerformanceIndicator { Name = "Partially meets job expectations" });
            }

            if (_context.PerformanceIndicators.FirstOrDefault(i => i.Name == "Does not meet job expectations") == null)
            {
                _context.PerformanceIndicators.Add(new PerformanceIndicator { Name = "Does not meet job expectations" });
            }


            if (_context.PerformanceIndicators.FirstOrDefault(i => i.Name == "Communication") == null)
            {
                _context.PerformanceIndicators.Add(new PerformanceIndicator { Name = "Communication" });
            }

            if (_context.PerformanceIndicators.FirstOrDefault(i => i.Name == "Job knowledge") == null)
            {
                _context.PerformanceIndicators.Add(new PerformanceIndicator { Name = "Job knowledge" });
            }


            if (_context.PerformanceIndicators.FirstOrDefault(i => i.Name == "Productivity") == null)
            {
                _context.PerformanceIndicators.Add(new PerformanceIndicator { Name = "Productivity" });
            }

            if (_context.PerformanceIndicators.FirstOrDefault(i => i.Name == "Quality of work") == null)
            {
                _context.PerformanceIndicators.Add(new PerformanceIndicator { Name = "Quality of work" });
            }


            if (_context.PerformanceIndicators.FirstOrDefault(i => i.Name == "Workplace Greivance and behaviour between employees") == null)
            {
                _context.PerformanceIndicators.Add(new PerformanceIndicator { Name = "Workplace Greivance and behaviour between employees" });
            }

            if (_context.PerformanceIndicators.FirstOrDefault(i => i.Name == "Safety") == null)
            {
                _context.PerformanceIndicators.Add(new PerformanceIndicator { Name = "Safety" });
            }

            if (_context.PerformanceIndicators.FirstOrDefault(i => i.Name == "Ability to negotiate and persuade") == null)
            {
                _context.PerformanceIndicators.Add(new PerformanceIndicator { Name = "Ability to negotiate and persuade" });
            }

            if (_context.PerformanceIndicators.FirstOrDefault(i => i.Name == "Punctuality as regards working hours") == null)
            {
                _context.PerformanceIndicators.Add(new PerformanceIndicator { Name = "Punctuality as regards working hours" });
            }

            if (_context.PerformanceIndicators.FirstOrDefault(i => i.Name == "Written and oral expression in regards working hours") == null)
            {
                _context.PerformanceIndicators.Add(new PerformanceIndicator { Name = "Written and oral expression in regards working hours" });
            }


        }
    }
}
