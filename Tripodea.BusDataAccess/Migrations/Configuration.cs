namespace Tripodea.BusDataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Tripodea.BusDataAccess.BusContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Tripodea.BusDataAccess.BusContext context)
        {
            InitializeDb.Initialize(context);
        }
    }
}
