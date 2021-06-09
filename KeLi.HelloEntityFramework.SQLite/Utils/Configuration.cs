using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;

using KeLi.HelloEntityFramework.SQLite.Properties;

namespace KeLi.HelloEntityFramework.SQLite.Utils
{
    internal sealed class Configuration : DbMigrationsConfiguration<GenericDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator(Resources.ProviderName, new SQLiteMigrationSqlGenerator());
        }
    }
}