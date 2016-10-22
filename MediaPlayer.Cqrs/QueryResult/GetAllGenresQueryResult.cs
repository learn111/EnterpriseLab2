using System.Collections.Generic;
using MediaPlayer.Core.Cqrs.Contracts;
using MediaPlayer.Cqrs.Aggregate;

namespace MediaPlayer.Cqrs.QueryResult
{
    public class GetAllGenresQueryResult : IQueryResult
    {
        public IEnumerable<GenreModel> Genres { get; set; }
    }
}