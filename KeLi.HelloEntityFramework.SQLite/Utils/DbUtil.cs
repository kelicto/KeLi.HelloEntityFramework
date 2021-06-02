using System;
using System.Collections.Generic;
using System.Linq;

namespace KeLi.HelloEntityFramework.SQLite.Utils
{
    internal class DbUtil
    {
        public static int Insert<T>(T entity, Func<T, bool> finder = null) where T : class
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            using (var context = new MyDbContext())
            {
                var data = context.Set<T>();
                var target = finder is null ? data.FirstOrDefault() : data.FirstOrDefault(finder);

                if (target is null)
                {
                    context.Set<T>().Add(entity);

                    return context.SaveChanges();
                }

                return 0;
            }
        }

        public static T Delete<T>(Func<T, bool> finder = null) where T : class
        {
            using (var context = new MyDbContext())
            {
                var data = context.Set<T>();
                var target = finder is null ? data.FirstOrDefault() : data.FirstOrDefault(finder);

                return data.Remove(target);
            }
        }

        public static int Update<T>(Action<T> updater, Func<T, bool> finder = null) where T : class
        {
            using (var context = new MyDbContext())
            {
                var data = context.Set<T>();
                var target = finder is null ? data.FirstOrDefault() : data.FirstOrDefault(finder);

                updater.Invoke(target);

                return context.SaveChanges();
            }
        }

        public static T Query<T>(Func<T, bool> finder = null) where T : class
        {
            using (var context = new MyDbContext())
            {
                var data = context.Set<T>();

                return finder is null ? data.FirstOrDefault() : data.FirstOrDefault(finder);
            }
        }

        public static List<T> QueryList<T>(Func<T, bool> finder = null) where T : class
        {
            using (var context = new MyDbContext())
            {
                if (finder is null)
                    return context.Set<T>().ToList();

                return context.Set<T>().Where(finder).ToList();
            }
        }
    }
}
