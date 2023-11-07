using Helpline.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Helpline.Repository
{
    public class GenericRepository<T> where T : class
    {
        internal HelplineDbContext _dbContext;
        internal DbSet<T> _dbSet;

        public GenericRepository(HelplineDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = dbContext.Set<T>();
        }

        /// <summary>
        /// Returns a list of models from the database.        
        /// </summary>
        /// <param name="predicate">Filter results.</param>
        /// <param name="includedProperties">Include these strings for eager loading.</param>
        /// <returns></returns>
        public virtual IList<T> GetList(Expression<Func<T, bool>> predicate = null,
            params string[] includedProperties)
        {
            IQueryable<T> query = _dbSet;

            if (includedProperties != null)
            {
                foreach (string includedProperty in includedProperties)
                {
                    query = query.Include(includedProperty);
                }
            }

            // The where clause must be added after the include eager loading method.
            if (predicate != null) query = query.Where(predicate);

            return query.ToList();
        }


        /// <summary>
        /// This method gets one model from the database.         
        /// </summary>
        /// <param name="predicate">Lambda condition that the first value matches.</param>
        /// <param name="inludedProperties">Eager Loading for related models.</param>
        /// <returns>First Model that matches the condition.</returns>
        public virtual T GetFirst(Expression<Func<T, bool>> predicate,
            params string[] inludedProperties)
        {
            IQueryable<T> query = _dbSet;

            if (inludedProperties != null)
            {
                foreach (string includedProperty in inludedProperties)
                {
                    query = query.Include(includedProperty);
                }
            }

            return query.Where(predicate).ToList<T>().FirstOrDefault();
        }


        /// <summary>
        /// Create New Entry
        /// </summary>
        /// <param name="t">New Entry</param>
        public virtual void Create(T t)
        {
            _dbSet.Add(t);
        }

        /// <summary>
        /// Edit pre-existing entry.
        /// </summary>
        /// <param name="t">Updated Entry</param>
        public virtual void Edit(T t)
        {
            _dbSet.Attach(t);
            _dbContext.Entry(t).State = EntityState.Modified;
        }

        /// <summary>
        /// Remove Entry
        /// </summary>
        /// <param name="t">Entry you want to remove.</param>
        public virtual void Remove(T t)
        {
            _dbSet.Remove(t);
        }

    }
}