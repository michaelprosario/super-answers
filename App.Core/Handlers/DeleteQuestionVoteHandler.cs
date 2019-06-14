using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;

namespace App.Core.Handlers
{
    public class DeleteQuestionVoteCommand : Command<VoidResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    public class DeleteQuestionVoteValidator : AbstractValidator<DeleteQuestionVoteCommand>
    {
        public DeleteQuestionVoteValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class DeleteQuestionVoteHandler : BaseHandler<DeleteQuestionVoteCommand, VoidResponse>
    {
        readonly IRepository<DbEntities.QuestionVote> _repository;
        public DeleteQuestionVoteHandler(IRepository<DbEntities.QuestionVote> repository)
        {
            _repository = repository;
        }
        protected override VoidResponse Handle(DeleteQuestionVoteCommand command)
        {
            var response = new VoidResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Request is null.");
            var validationResult = new DeleteQuestionVoteValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = _repository.GetById(command.Id);
            if (record == null) {
                response.Code = ResponseCode.NotFound;
                return response;
            }
            _repository.Delete(record);

            return response;
        }
    }
}

