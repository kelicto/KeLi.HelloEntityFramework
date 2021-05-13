using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;

using KeLi.HelloEntityFramework.SQLite.DataModels;

namespace KeLi.HelloEntityFramework.SQLite
{
    public class MyDbContext : DbContext, IDisposable
    {
        static MyDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Configuration>());
        }

        public DbSet<Student> StudentSet { get; set; }

        public MyDbContext(string nameOrConnectionString = "DefaultConnection") : base(nameOrConnectionString)
        {
            Database.Log = GetLog;
        }

        public MyDbContext(SQLiteConnection connection) : base(connection, false)
        {
            Database.Log = GetLog;
        }

        public new void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }

        ~MyDbContext()
        {
            base.Dispose();
        }

        private void GetLog(string sql)
        {
            System.Diagnostics.Debug.Write(sql);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(typeof(MyDbContext).Assembly);
        }
    }
}