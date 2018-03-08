using SoftBreeze.BlueHrm.EntityFramework;
using SoftBreeze.BlueHrm.Migrations.Seed;

namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SoftBreeze.BlueHrm.EntityFramework.BlueHrmDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlueHrmDbContext context)
        {
            new InitialDbBuilder(context).Create();
        }
    }
}
