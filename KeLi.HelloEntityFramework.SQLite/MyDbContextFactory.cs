using System.Data.Entity.Infrastructure;
using System.Data.SQLite;

using KeLi.HelloEntityFramework.SQLite.Properties;
using KeLi.HelloEntityFramework.SQLite.Utils;

namespace KeLi.HelloEntityFramework.SQLite
{
    public class MyDbContextFactory : IDbContextFactory<MyDbContext>
    {
        public MyDbContext Create()
        {
            return new MyDbContext(new SQLiteConnection(Resources.ConnectionString));
        }
    }
}