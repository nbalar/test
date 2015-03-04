using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace VenomitIT.DAL
{
    public class BaseDAL<T> : VenomitITEntityModel where T : class
    {
        public static void Add(T entity)
        {
            EntityModel.CreateObjectSet<T>().AddObject(entity);
            EntityModel.SaveChanges();
        }

        public static void Update(T entity)
        {
            EntityModel.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Unchanged);
            EntityModel.CreateObjectSet<T>().Attach(entity);
            EntityModel.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
            EntityModel.SaveChanges();
        }

        public static void Delete(T entity)
        {
            EntityModel.CreateObjectSet<T>().DeleteObject(entity);
            EntityModel.SaveChanges();
        }

        public static void DeleteMultiple(ICollection<T> entities)
        {
            var dbSet = EntityModel.CreateObjectSet<T>();
            foreach (var item in entities)
            {
                dbSet.DeleteObject(item);
            }
            EntityModel.SaveChanges();

        }


        public static T Get(Func<T, bool> expression)
        {
            return EntityModel.CreateObjectSet<T>().FirstOrDefault(expression);
        }

        public static IQueryable<T> FetchAll(Func<T, bool> expression)
        {
            return EntityModel.CreateObjectSet<T>().Where(expression).AsQueryable();
        }

        public static IQueryable<T> FetchAll()
        {
            return EntityModel.CreateObjectSet<T>().AsQueryable();
        }

        public static bool IsExists(Func<T, bool> expression)
        {
            return EntityModel.CreateObjectSet<T>().Any(expression);
        }
    }
}
