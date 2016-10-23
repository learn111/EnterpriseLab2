using System.Threading.Tasks;
using System.Web.Mvc;
using MediaPlayer.Core.Cqrs.Contracts;
using MediaPlayer.Cqrs.Command;
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
        public async Task<ActionResult> Index()
            => View(await QueryDispatcher.Dispatch<GetAllGenresQuery, GetAllGenresQueryResult>(new GetAllGenresQuery()));

        public async Task<ActionResult> Create() => View(new CreateGenreCommand());

        [HttpPost]
        public async Task<ActionResult> Create(CreateGenreCommand command)
        {
            await CommandDispatcher.Dispatch(command);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(DeleteGenreCommand command)
        {
            await CommandDispatcher.Dispatch(command);
            return RedirectToAction("Index");
        }

      
    }
}