using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Handlers
{
    public interface IExecuteHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        TResponse Execute(TRequest request);
    }
}
