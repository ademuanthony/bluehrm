using EntityFramework.DynamicFilters;
using SoftBreeze.BlueHrm.EntityFramework;

namespace SoftBreeze.BlueHrm.Migrations.Seed
{
    public class InitialDbBuilder
    {
        private readonly BlueHrmDbContext _context;

        public InitialDbBuilder(BlueHrmDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new DefaultTenantRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new InitialPeopleCreator(_context).Create();
            new HrmSeed(_context).Create();

            _context.SaveChanges();
        }
    }
}
