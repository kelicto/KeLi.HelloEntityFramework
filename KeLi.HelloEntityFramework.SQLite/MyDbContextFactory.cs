using System.Data.Entity.Infrastructure;
using System.Data.SQLite;

namespace KeLi.HelloEntityFramework.SQLite
{
    public class MyDbContextFactory : IDbContextFactory<MyDbContext>
    {
        public MyDbContext Create()
        {
            return new MyDbContext(new SQLiteConnection(@"data source=MyDatabase.db"));
        }
    }
}