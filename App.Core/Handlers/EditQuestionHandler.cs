using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using System.Runtime.Serialization;

namespace App.Core.Handlers
{
    public class EditQuestionCommand : Command<EditQuestionResponse>, IUserRequest
    {
        public string QuestionTitle { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public bool NotifyMeOnResponse { get; set; }
        public string UserId { get; set; }
        public string QuestionId { get; set; }
    }

    public class EditQuestionRequestValidator : AbstractValidator<EditQuestionCommand>
    {
        public EditQuestionRequestValidator()
        {
            RuleFor(x => x.QuestionId).NotEmpty();
            RuleFor(x => x.QuestionTitle).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    [DataContract]
    public class EditQuestionResponse : Response
    {
        [DataMember]
        public string Id { get; set; }
    }
    
    public class EditQuestionHandler : BaseHandler<EditQuestionCommand, EditQuestionResponse>
    {
        IRepository<DbEntities.Question> _repository;
        public EditQuestionHandler(IRepository<DbEntities.Question> repository)
        {
            _repository = repository;
        }
        protected override EditQuestionResponse Handle(EditQuestionCommand command)
        {
            var response = new EditQuestionResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Request is null.");
            var validationResult = new EditQuestionRequestValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = _repository.GetById(command.QuestionId);
            record.Content = command.Content;
            record.QuestionTitle = command.QuestionTitle;
            record.Tags = command.Tags;
       
            HandlerUtilities.TimeStampRecord(record, command.UserId, false);
            _repository.Update(record);

            return response;
        }
    }
}