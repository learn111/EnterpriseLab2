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
    public class GetAllSingersQueryHandler : IQueryHandler<GetAllSingersQuery, GetAllSingersQueryResult>
    {
        private readonly IMediaContextWrapper _contextWrapper;

        public GetAllSingersQueryHandler(IMediaContextWrapper contextWrapper)
        {
            _contextWrapper = contextWrapper;
        }

        public async Task<GetAllSingersQueryResult> Retrieve(GetAllSingersQuery query)
        {
            var result = await _contextWrapper.CallAsync(async ctx => Mapper.Map<List<SingerModel>>(await ctx.Singers.ToListAsync()));
            return new GetAllSingersQueryResult() {Singers = result};
        }
    }
}