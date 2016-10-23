using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using MediaPlayer.Core.Cqrs.Contracts;
using MediaPlayer.Cqrs.Command.Tracks;
using MediaPlayer.Cqrs.Query;
using MediaPlayer.Cqrs.QueryResult;
using MediaPlayer.Web.Models;

namespace MediaPlayer.Web.Controllers
{
    public class TrackController : ControllerBase
    {
        public TrackController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
            : base(queryDispatcher, commandDispatcher)
        {
        }

        public async Task<ViewResult> Create()
        {
            var singers =
                await QueryDispatcher.Dispatch<GetAllSingersQuery, GetAllSingersQueryResult>(new GetAllSingersQuery());

            return View(new TracksViewModels.CreateTrackViewModel()
            {
                SelectSingerViewModels = AutoMapper.Mapper.Map<List<SingerViewModels.SelectSingerViewModel>>(singers.Singers)
            });
        }
    }
}