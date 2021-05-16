using System;
using System.Collections.Generic;
using System.Linq;

namespace KeLi.HelloEntityFramework.SQLite.Utils
{
    internal class DbUtil
    {
        public static int Insert<T>(T entity) where T : class
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            using (var context = new MyDbContext())
            {
                context.Set<T>().Add(entity);

                return context.SaveChanges();
            }
        }

        public static T Delete<T>(Func<T, bool> func = null) where T : class
        {
            if (func is null)
                throw new ArgumentNullException(nameof(func));

            using (var context = new MyDbContext())
            {
                var target = func is null ? context.Set<T>().FirstOrDefault() : context.Set<T>().FirstOrDefault(func);

                return context.Set<T>().Remove(target);
            }
        }

        public static int Update<T>(Func<T, bool> func, Action<T> action) where T : class
        {
            if (func is null)
                throw new ArgumentNullException(nameof(func));

            using (var context = new MyDbContext())
            {
                var target = func is null ? context.Set<T>().FirstOrDefault() : context.Set<T>().FirstOrDefault(func);

                action.Invoke(target);

                return context.SaveChanges();
            }
        }

        public static T Query<T>(Func<T, bool> func = null) where T : class
        {
            using (var context = new MyDbContext())
            {
                if (func is null)
                    return context.Set<T>().FirstOrDefault();

                return context.Set<T>().FirstOrDefault(func);
            }
        }

        public static List<T> QueryList<T>(Func<T, bool> func = null) where T : class
        {
            using (var context = new MyDbContext())
            {
                if (func is null)
                    return context.Set<T>().ToList();

                return context.Set<T>().Where(func).ToList();
            }
        }
    }
}
