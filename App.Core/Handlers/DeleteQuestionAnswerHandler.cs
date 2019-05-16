using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using MediatR;

namespace App.Core.Handlers
{
    public class DeleteQuestionAnswerRequest : IRequest<VoidResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    public class DeleteQuestionAnswerValidator : AbstractValidator<DeleteQuestionAnswerRequest>
    {
        public DeleteQuestionAnswerValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class DeleteQuestionAnswerHandler : BaseHandler<DeleteQuestionAnswerRequest, VoidResponse>
    {
        readonly IRepository<DbEntities.QuestionAnswer> _repository;
        public DeleteQuestionAnswerHandler(IRepository<DbEntities.QuestionAnswer> repository)
        {
            _repository = repository;
        }
        protected override VoidResponse Handle(DeleteQuestionAnswerRequest request)
        {
            var response = new VoidResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var validationResult = new DeleteQuestionAnswerValidator().Validate(request);
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

