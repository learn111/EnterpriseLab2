﻿using System.Threading.Tasks;

namespace MediaPlayer.Core.Cqrs.Contracts
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult;
    }
}