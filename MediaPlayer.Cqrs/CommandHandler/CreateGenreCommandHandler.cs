using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediaPlayer.Core.Cqrs.Contracts;
using MediaPlayer.Core.Cqrs.Implementation;
using MediaPlayer.Cqrs.Command;
using MediaPlayer.Data;
using MediaPlayer.Data.Entities;

namespace MediaPlayer.Cqrs.CommandHandler
{
    public class CreateGenreCommandHandler : ICommandHandler<CreateGenreCommand>
    {
        private readonly IMediaContextWrapper _contextWrapper;

        public CreateGenreCommandHandler(IMediaContextWrapper contextWrapper)
        {
            _contextWrapper = contextWrapper;
        }

        public async Task<CommandResult> Execute(CreateGenreCommand command)
        {
            try
            {
                await _contextWrapper.CallAsync(async ctx =>
                {
                    ctx.Genres.Add(Mapper.Map<CreateGenreCommand, Genre>(command));
                    await ctx.SaveChangesAsync(CancellationToken.None);
                });
                return new CommandResult {Success = true};
            }
            catch (Exception ex)
            {
                return new CommandResult
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}