using System;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MediaPlayer.Data.DbContextWrapper
{
    public class DbContextWrapper<TContext> : IDbContextWrapper<TContext> where TContext : DbContext, new()
    {
        public TContext BuildContext(bool enableChangeTracking = false, bool enableLazyLoading = false,
            bool enableProxyCreation = false)
        {
            var context = new TContext();
            context.Configuration.ProxyCreationEnabled = enableProxyCreation;
            context.Configuration.AutoDetectChangesEnabled = enableChangeTracking;
            context.Configuration.LazyLoadingEnabled = enableLazyLoading;
            return context;
        }

        public virtual T Call<T>(Func<TContext, T> func)
        {
            using (var ctx = BuildContext())
            {
                return func(ctx);
            }
        }

        public virtual void Call(Action<TContext> action)
        {
            using (var ctx = BuildContext())
            {
                action(ctx);
            }
        }

        public virtual async Task<T> CallAsync<T>(Func<TContext, Task<T>> func)
        {
            using (var ctx = BuildContext())
            {
                return await func(ctx).ConfigureAwait(false);
            }
        }

        public async Task CallAsync(Func<TContext, Task> func)
        {
            using (var ctx = BuildContext())
            {
                await func(ctx).ConfigureAwait(false);
            }
        }

        public virtual T CallWithTransaction<T>(Func<TContext, T> func,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var ctx = BuildContext())
            {
                using (var transaction = ctx.Database.BeginTransaction(isolationLevel))
                {
                    var result = func(ctx);
                    transaction.Commit();
                    return result;
                }
            }
        }

        public void CallWithTransaction(Action<TContext> action,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var ctx = BuildContext())
            {
                using (var transaction = ctx.Database.BeginTransaction(isolationLevel))
                {
                    action(ctx);
                    transaction.Commit();
                }
            }
        }

        public async Task<T> CallWithTransactionAsync<T>(Func<TContext, Task<T>> func,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var ctx = BuildContext())
            {
                using (var transaction = ctx.Database.BeginTransaction(isolationLevel))
                {
                    var result = await func(ctx).ConfigureAwait(false);
                    transaction.Commit();
                    return result;
                }
            }
        }

        public async Task CallWithTransactionAsync(Func<TContext, Task> func,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var ctx = BuildContext())
            {
                using (var transaction = ctx.Database.BeginTransaction(isolationLevel))
                {
                    await func(ctx).ConfigureAwait(false);
                    transaction.Commit();
                }
            }
        }
    }
}