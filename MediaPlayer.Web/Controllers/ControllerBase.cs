using System.Web.Mvc;
using MediaPlayer.Core.Cqrs.Contracts;

namespace MediaPlayer.Web.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;
        protected readonly IQueryDispatcher QueryDispatcher;

        public ControllerBase(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            QueryDispatcher = queryDispatcher;
            CommandDispatcher = commandDispatcher;
        }
    }
}