using System;
using System.Threading.Tasks;
using AutoMapper;
using MediaPlayer.Core.Cqrs.Contracts;
using MediaPlayer.Core.Cqrs.Implementation;
using MediaPlayer.Cqrs.Command.Tracks;
using MediaPlayer.Data;
using MediaPlayer.Data.Entities;

namespace MediaPlayer.Cqrs.CommandHandler.Tracks
{
    public class CreateTrackCommandHandler : ICommandHandler<CreateTrackCommand>
    {
        private readonly IMediaContextWrapper _contextWrapper;

        public CreateTrackCommandHandler(IMediaContextWrapper contextWrapper)
        {
            _contextWrapper = contextWrapper;
        }

        public async Task<CommandResult> Execute(CreateTrackCommand command)
        {
            var track = Mapper.Map<Track>(command);
            try
            {
                await _contextWrapper.CallAsync(async ctx =>
                {
                    ctx.Tracks.Add(track);
                    await ctx.SaveChangesAsync();
                });
                return new CommandResult()
                {
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new CommandResult()
                {
                    Success = false,
                    Message = exception.Message
                };
            }
        }
    }
}