using System.Threading.Tasks;
using MediaPlayer.Core.Cqrs.Implementation;

namespace MediaPlayer.Core.Cqrs.Contracts
{
    public interface ICommandDispatcher
    {
        Task<CommandResult> Dispatch<TParamerer>(TParamerer command)
            where TParamerer : ICommand;
    }
}