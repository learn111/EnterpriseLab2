using System;
using System.Threading.Tasks;
using MediaPlayer.Core.Cqrs.Contracts;
using MediaPlayer.Core.Ioc;

namespace MediaPlayer.Core.Cqrs.Implementation
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IContainer _container;

        public QueryDispatcher(IContainer container)
        {
            _container = container;
            if (container == null)
                throw new ArgumentException("container cannot be null");
        }

        public async Task<TResult> Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult
        {
            var handler = _container.Resolve<IQueryHandler<TParameter, TResult>>();
            return await handler.Retrieve(query);
        }
    }
}