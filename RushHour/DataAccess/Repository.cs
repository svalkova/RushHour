using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using RushHour.Models;
using System.Linq.Expressions;
using System.Data.Entity;

namespace RushHour.DataAccess
{
    public abstract class Repository<T> :IDisposable  where T : BaseEntity
    {
        protected RushHourContext context;
        private DbSet<T> dbSet;

        public Repository(RushHourContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public Repository() : this(new RushHourContext())
        {
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter=null)
        {
            return dbSet.Where(filter).ToList();
        }

        public T GetById(int? id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T t)
        {
            context.Entry(t).State = EntityState.Added;
            context.SaveChanges();
        }

        //or delete by id - Note note = context.Notes.Find(id);
        public void Delete(T t)
        {
            dbSet.Remove(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            context.Entry(t).State = EntityState.Modified;
            context.SaveChanges();
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Repository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}