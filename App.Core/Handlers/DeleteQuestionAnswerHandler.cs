using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using System;

namespace App.Core.Handlers
{
    public class DeleteQuestionAnswerCommand : Command<VoidResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    public class DeleteQuestionAnswerValidator : AbstractValidator<DeleteQuestionAnswerCommand>
    {
        public DeleteQuestionAnswerValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class DeleteQuestionAnswerHandler : BaseHandler<DeleteQuestionAnswerCommand, VoidResponse>
    {
        readonly IRepository<DbEntities.QuestionAnswer> _repository;
        public DeleteQuestionAnswerHandler(IRepository<DbEntities.QuestionAnswer> repository)
        {
            _repository = repository;
        }
        protected override VoidResponse Handle(DeleteQuestionAnswerCommand command)
        {
            var response = new VoidResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Request is null.");
            var validationResult = new DeleteQuestionAnswerValidator().Validate(command);
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

            record.DeleteAt = DateTime.Now;
            record.DeletedBy = command.UserId;
            record.IsDeleted = true;
            _repository.Update(record);

            return response;
        }
    }
}

