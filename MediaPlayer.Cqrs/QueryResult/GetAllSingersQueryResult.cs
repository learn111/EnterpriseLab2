using System.Collections.Generic;
using MediaPlayer.Core.Cqrs.Contracts;
using MediaPlayer.Cqrs.Aggregate;

namespace MediaPlayer.Cqrs.QueryResult
{
    public class GetAllSingersQueryResult : IQueryResult
    {
        public IEnumerable<SingerModel> Singers { get; set; }
    }
}