using System.Data.Entity.Infrastructure;
using System.Data.SQLite;

using KeLi.HelloEntityFramework.SQLite.Properties;

namespace KeLi.HelloEntityFramework.SQLite.Models
{
    public class GenericDbContextFactory : IDbContextFactory<GenericDbContext>
    {
        public GenericDbContext Create()
        {
            return new GenericDbContext(new SQLiteConnection(Resources.ConnectionString));
        }
    }
}