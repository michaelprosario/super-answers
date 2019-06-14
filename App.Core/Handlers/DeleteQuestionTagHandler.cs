using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;

namespace App.Core.Handlers
{
    public class DeleteQuestionTagCommand : Command<VoidResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    public class DeleteQuestionTagValidator : AbstractValidator<DeleteQuestionTagCommand>
    {
        public DeleteQuestionTagValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class DeleteQuestionTagHandler : BaseHandler<DeleteQuestionTagCommand, VoidResponse>
    {
        readonly IRepository<DbEntities.QuestionTag> _repository;
        public DeleteQuestionTagHandler(IRepository<DbEntities.QuestionTag> repository)
        {
            _repository = repository;
        }
        protected override VoidResponse Handle(DeleteQuestionTagCommand command)
        {
            var response = new VoidResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Request is null.");
            var validationResult = new DeleteQuestionTagValidator().Validate(command);
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

