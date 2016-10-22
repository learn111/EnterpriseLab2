using System.Threading.Tasks;

namespace MediaPlayer.Core.Cqrs.Contracts
{
    public interface IQueryHandler<in TParameter, TResult>
        where TParameter : IQuery
        where TResult : IQueryResult
    {
        Task<TResult> Retrieve(TParameter query);
    }
}