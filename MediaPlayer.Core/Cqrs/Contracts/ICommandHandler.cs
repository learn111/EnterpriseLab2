using System.Threading.Tasks;
using MediaPlayer.Core.Cqrs.Implementation;

namespace MediaPlayer.Core.Cqrs.Contracts
{
    public interface ICommandHandler<in TParameter>
        where TParameter : ICommand
    {
        Task<CommandResult> Execute(TParameter command);
    }
}