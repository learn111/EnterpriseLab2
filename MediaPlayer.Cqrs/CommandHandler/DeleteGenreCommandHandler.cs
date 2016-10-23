using System;
using System.Threading;
using System.Threading.Tasks;
using MediaPlayer.Core.Cqrs.Contracts;
using MediaPlayer.Core.Cqrs.Implementation;
using MediaPlayer.Cqrs.Command;
using MediaPlayer.Data;

namespace MediaPlayer.Cqrs.CommandHandler
{
    public class DeleteGenreCommandHandler : ICommandHandler<DeleteGenreCommand>
    {
        private readonly IMediaContextWrapper _contextWrapper;

        public DeleteGenreCommandHandler(IMediaContextWrapper contextWrapper)
        {
            _contextWrapper = contextWrapper;
        }

        public async Task<CommandResult> Execute(DeleteGenreCommand command)
        {
            try
            {
                await _contextWrapper.CallAsync(async ctx =>
                {
                    ctx.Genres.Remove(await ctx.Genres.FindAsync(command.GenreId));
                    await ctx.SaveChangesAsync(CancellationToken.None);
                });
            }
            catch (Exception ex)
            {
                return new CommandResult
                {
                    Message = ex.Message,
                    Success = false
                };
            }
            return new CommandResult {Success = true};
        }
    }
}