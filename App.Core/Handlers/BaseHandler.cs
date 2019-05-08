using MediatR;

namespace App.Core.Handlers
{
    public abstract class BaseHandler<TRequest, TResponse> : RequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public TResponse Execute(TRequest request)
        {
            return this.Handle(request);
        }

        protected abstract override TResponse Handle(TRequest request);
    }
}
