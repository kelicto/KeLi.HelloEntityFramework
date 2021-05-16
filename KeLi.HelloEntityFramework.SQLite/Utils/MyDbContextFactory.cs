using System.Data.Entity.Infrastructure;
using System.Data.SQLite;

using KeLi.HelloEntityFramework.SQLite.Properties;

namespace KeLi.HelloEntityFramework.SQLite.Utils
{
    public class MyDbContextFactory : IDbContextFactory<MyDbContext>
    {
        public MyDbContext Create()
        {
            return new MyDbContext(new SQLiteConnection(Resources.ConnectionString));
        }
    }
}