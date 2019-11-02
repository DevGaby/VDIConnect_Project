namespace VDIConnect_API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VDIConnect_API.DAL.VDIConnectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
<<<<<<< HEAD
=======
            ContextKey = "VDIConnect_API.DAL.VDIConnectContext";
>>>>>>> 95bf0f4e67f1b5f7c0af299eb45fa3b3e174cebb
        }

        protected override void Seed(VDIConnect_API.DAL.VDIConnectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
