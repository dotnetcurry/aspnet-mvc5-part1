using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Michaels_Stuff.Models.Repositories
{
    public class Repository<T> where T : class, new()
    {
        private KendallsoftEntity context = new KendallsoftEntity();

        private DbSet<T> set;

        public Repository()
        {
            set = context.Set<T>();
        }

        protected DbSet<T> Set
        {
            get { return set; }
        }

        public T GetByID(Int32 id)
        {
            // does a search based on ID (key)
            // Returns the item if found, null if not found
            return Set.Find(id);
        }

        public List<T> GetAll()
        {
            return Set.ToList();
        }

        public void Create(T entity)
        {
            set.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            // once we return the response to the user, the object is disconnected
            // from the context. In order for updates and deletes to work, the object
            // must be added back on
            set.Attach(entity);

            // Must tell the context the object is changed
            context.Entry<T>(entity).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            set.Attach(entity);
            set.Remove(entity);
            context.SaveChanges();
        }
    }
}