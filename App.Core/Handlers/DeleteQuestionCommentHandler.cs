using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using MediatR;

namespace App.Core.Handlers
{
    public class DeleteQuestionCommentCommand : IRequest<VoidResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    public class DeleteQuestionCommentValidator : AbstractValidator<DeleteQuestionCommentCommand>
    {
        public DeleteQuestionCommentValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class DeleteQuestionCommentHandler : BaseHandler<DeleteQuestionCommentCommand, VoidResponse>
    {
        readonly IRepository<DbEntities.QuestionComment> _repository;
        public DeleteQuestionCommentHandler(IRepository<DbEntities.QuestionComment> repository)
        {
            _repository = repository;
        }
        protected override VoidResponse Handle(DeleteQuestionCommentCommand command)
        {
            var response = new VoidResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Command is null.");
            var validationResult = new DeleteQuestionCommentValidator().Validate(command);
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

