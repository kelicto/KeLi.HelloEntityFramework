using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;

namespace KeLi.HelloEntityFramework.SQLite
{
    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }
    }
}