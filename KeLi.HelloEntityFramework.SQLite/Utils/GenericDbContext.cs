using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;

using KeLi.HelloEntityFramework.SQLite.Models;

namespace KeLi.HelloEntityFramework.SQLite.Utils
{
    public class GenericDbContext : DbContext, IDisposable
    {
        static GenericDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GenericDbContext, Configuration>());
        }

        public DbSet<Student> StudentSet { get; set; }

        public GenericDbContext(string connectionString) : base(connectionString)
        {
            Database.Log = GetLog;
        }

        public GenericDbContext(SQLiteConnection connection) : base(connection, false)
        {
            Database.Log = GetLog;
        }

        public new void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }

        ~GenericDbContext()
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
            modelBuilder.Configurations.AddFromAssembly(typeof(GenericDbContext).Assembly);
        }
    }
}