using System.Threading.Tasks;
using System.Web.Mvc;
using MediaPlayer.Core.Cqrs.Contracts;
using MediaPlayer.Cqrs.Query;
using MediaPlayer.Cqrs.QueryResult;

namespace MediaPlayer.Web.Controllers
{
    public class GenreController : ControllerBase
    {
        public GenreController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
            : base(queryDispatcher, commandDispatcher)
        {
        }

        // GET: Genre
        public async Task<ActionResult> Index() => View(await QueryDispatcher.Dispatch<GetAllGenresQuery, GetAllGenresQueryResult>(new GetAllGenresQuery()));
    }
}