using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;

using KeLi.HelloEntityFramework.SQLite.Properties;

namespace KeLi.HelloEntityFramework.SQLite.Contexts
{
    internal sealed class GenericDbMigrationsConfiguration : DbMigrationsConfiguration<GenericDbContext>
    {
        public GenericDbMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator(Resources.ProviderName, new SQLiteMigrationSqlGenerator());
        }
    }
}