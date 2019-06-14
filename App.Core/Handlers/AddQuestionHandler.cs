using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using System.Runtime.Serialization;

namespace App.Core.Handlers
{
    public class AddQuestionCommand : Command<AddQuestionResponse>, IUserRequest
    {
        public string QuestionTitle { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public bool NotifyMeOnResponse { get; set; }
        public string UserId { get; set; }
    }

    public class AddQuestionCommandValidator : AbstractValidator<AddQuestionCommand>
    {
        public AddQuestionCommandValidator()
        {
            RuleFor(x => x.QuestionTitle).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class AddQuestionResponse : Response
    {
        [DataMember] public string Id { get; set; }
    }

    public class AddQuestionHandler : BaseHandler<AddQuestionCommand, AddQuestionResponse>
    {
        readonly IRepository<DbEntities.Question> _repository;

        public AddQuestionHandler(IRepository<DbEntities.Question> repository)
        {
            _repository = repository;
        }

        protected override AddQuestionResponse Handle(AddQuestionCommand command)
        {
            var response = new AddQuestionResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Request is null.");
            var validationResult = new AddQuestionCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = new DbEntities.Question
            {
                Content = command.Content,
                QuestionTitle = command.QuestionTitle,
                Tags = command.Tags
            };

            HandlerUtilities.TimeStampRecord(record, command.UserId, true);
            var returnRecord = _repository.Add(record);
            response.Id = returnRecord.Id;

            return response;
        }
    }
}