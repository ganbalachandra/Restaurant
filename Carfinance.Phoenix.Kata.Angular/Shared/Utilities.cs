using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Carfinance.Phoenix.Kata.Angular.Shared
{
    public static class Utilities
    {
        public enum ObjectState
        {
            Unchanged = 0,
            Added = 1,
            Modified = 2,
            Deleted = 3
        }
        public interface IStateObject
        {
            ObjectState State { get; }
        }
        public static Expression<Func<TEntity, bool>> BuildLambdaForFindByKey<TEntity>(int id)
        {
            var item = Expression.Parameter(typeof(TEntity), "entity");
            var prop = Expression.Property(item, typeof(TEntity).Name + "Id");
            var value = Expression.Constant(id);
            var equal = Expression.Equal(prop, value);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
            return lambda;
        }

        private static EntityState ConvertState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Added:
                    return EntityState.Added;

                case ObjectState.Modified:
                    return EntityState.Modified;

                case ObjectState.Deleted:
                    return EntityState.Deleted;

                default:
                    return EntityState.Unchanged;
            }
        }

        public static void FixState(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IStateObject>())
            {
                IStateObject stateInfo = entry.Entity;
                entry.State = ConvertState(stateInfo.State);
            }
        }
    }
}