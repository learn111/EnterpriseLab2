using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using MediaPlayer.Core.Cqrs.Contracts;
using MediaPlayer.Cqrs.Aggregate;
using MediaPlayer.Cqrs.Query;
using MediaPlayer.Cqrs.QueryResult;
using MediaPlayer.Data;

namespace MediaPlayer.Cqrs.QueryHandler
{
    public class GetAllGenresQueryHandler : IQueryHandler<GetAllGenresQuery, GetAllGenresQueryResult>
    {
        private readonly IMediaContextWrapper _contextWrapper;

        public GetAllGenresQueryHandler(IMediaContextWrapper contextWrapper)
        {
            _contextWrapper = contextWrapper;
        }

        public async Task<GetAllGenresQueryResult> Retrieve(GetAllGenresQuery query) => new GetAllGenresQueryResult()
        {
            Genres = Mapper.Map<List<GenreModel>>(await _contextWrapper.CallAsync(ctx => ctx.Genres.ToListAsync()))
        };
    }
}