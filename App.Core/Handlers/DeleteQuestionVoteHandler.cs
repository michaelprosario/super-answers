using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using MediatR;

namespace App.Core.Handlers
{
    public class DeleteQuestionVoteRequest : IRequest<VoidResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    public class DeleteQuestionVoteValidator : AbstractValidator<DeleteQuestionVoteRequest>
    {
        public DeleteQuestionVoteValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class DeleteQuestionVoteHandler : BaseHandler<DeleteQuestionVoteRequest, VoidResponse>
    {
        readonly IRepository<DbEntities.QuestionVote> _repository;
        public DeleteQuestionVoteHandler(IRepository<DbEntities.QuestionVote> repository)
        {
            _repository = repository;
        }
        protected override VoidResponse Handle(DeleteQuestionVoteRequest request)
        {
            var response = new VoidResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var validationResult = new DeleteQuestionVoteValidator().Validate(request);
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

