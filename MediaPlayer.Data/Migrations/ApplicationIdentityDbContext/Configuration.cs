using System.Data.Entity.Migrations;

namespace MediaPlayer.Data.Migrations.ApplicationIdentityDbContext
{
    internal sealed class Configuration : DbMigrationsConfiguration<Data.ApplicationIdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"Migrations\ApplicationIdentityDbContext";
        }

        protected override void Seed(Data.ApplicationIdentityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}