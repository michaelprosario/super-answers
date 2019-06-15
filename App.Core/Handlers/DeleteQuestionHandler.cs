using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using System;

namespace App.Core.Handlers
{
    public class DeleteQuestionCommand : Command<VoidResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    public class DeleteQuestionValidator : AbstractValidator<DeleteQuestionCommand>
    {
        public DeleteQuestionValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class DeleteQuestionHandler : BaseHandler<DeleteQuestionCommand, VoidResponse>
    {
        IRepository<DbEntities.Question> _repository;
        public DeleteQuestionHandler(IRepository<DbEntities.Question> repository)
        {
            _repository = repository;
        }
        protected override VoidResponse Handle(DeleteQuestionCommand command)
        {
            var response = new VoidResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Request is null.");
            var validationResult = new DeleteQuestionValidator().Validate(command);
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