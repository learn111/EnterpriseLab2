using System;
using System.Threading.Tasks;
using MediaPlayer.Core.Cqrs.Contracts;
using MediaPlayer.Core.Ioc;

namespace MediaPlayer.Core.Cqrs.Implementation
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IContainer _container;

        public CommandDispatcher(IContainer container)
        {
            if(container==null)
                throw new ArgumentNullException(nameof(container));
            _container = container;
        }

        public async Task<CommandResult> Dispatch<TParamerer>(TParamerer command) where TParamerer : ICommand
        {
            var handler = _container.Resolve<ICommandHandler<TParamerer>>();
            return await handler.Execute(command);
        }
    }
}