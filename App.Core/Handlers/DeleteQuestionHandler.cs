using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using MediatR;

namespace App.Core.Handlers
{
    public class DeleteQuestionRequest : IRequest<VoidResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    public class DeleteQuestionValidator : AbstractValidator<DeleteQuestionRequest>
    {
        public DeleteQuestionValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class DeleteQuestionHandler : BaseHandler<DeleteQuestionRequest, VoidResponse>
    {
        IRepository<Question> _repository;
        public DeleteQuestionHandler(IRepository<Question> repository)
        {
            _repository = repository;
        }
        protected override VoidResponse Handle(DeleteQuestionRequest request)
        {
            var response = new VoidResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var validationResult = new DeleteQuestionValidator().Validate(request);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = _repository.GetById(request.Id);
            if (record == null) {
                response.Code = ResponseCode.NotFound;
                return response;
            }
            _repository.Delete(record);

            return response;
        }
    }
}