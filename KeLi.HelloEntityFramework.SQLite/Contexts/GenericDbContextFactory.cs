using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;

using KeLi.HelloEntityFramework.SQLite.Properties;

namespace KeLi.HelloEntityFramework.SQLite.Contexts
{
    public class GenericDbContextFactory : IDbContextFactory<GenericDbContext>
    {
        public GenericDbContext Create()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[Resources.Key_MyDatabase].ConnectionString;
            var connection = new SQLiteConnection(connectionString);

            return new GenericDbContext(connection);
        }
    }
}