﻿using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;

using KeLi.HelloEntityFramework.SQLite.DataModels;
using KeLi.HelloEntityFramework.SQLite.Properties;

namespace KeLi.HelloEntityFramework.SQLite.Utils
{
    public class MyDbContext : DbContext, IDisposable
    {
        static MyDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Configuration>());
        }

        public DbSet<Student> StudentSet { get; set; }

        public MyDbContext() : base(Resources.ConnectionName)
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