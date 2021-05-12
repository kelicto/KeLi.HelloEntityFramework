using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using KeLi.HelloSQLite.App.Entities;

namespace KeLi.HelloSQLite.App
{
    public class AppDBContext : DbContext, IDisposable
    {
        static AppDBContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDBContext, Configuration>());
        }

        public DbSet<Student> StudentSet { get; set; }

        public AppDBContext() : base("DefaultConnection")
        {
            Database.Log = GetLog;
        }

        public new void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }

        ~AppDBContext()
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
            modelBuilder.Configurations.AddFromAssembly(typeof(AppDBContext).Assembly);
        }
    }
}