using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;

namespace KeLi.HelloSqlLite.App
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }
    }
}