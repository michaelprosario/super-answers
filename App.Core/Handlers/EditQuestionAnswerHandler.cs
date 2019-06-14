using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using System.Runtime.Serialization;

namespace App.Core.Handlers
{
    public class EditQuestionAnswerCommand : Command<EditQuestionAnswerResponse>, IUserRequest
    {
        [DataMember(Order=1)]
        public string Id { get; set; }
               
        [DataMember(Order = 3)]
        public string Answer { get; set; }
        
        [DataMember(Order =9)]
        public string UserId { get; set; }
    }

    public class EditQuestionAnswerRequestValidator : AbstractValidator<EditQuestionAnswerCommand>
    {
        public EditQuestionAnswerRequestValidator()
        {
            RuleFor(r => r.Answer).NotEmpty();
            RuleFor(r => r.UserId).NotEmpty();
        }
    }

    [DataContract]
    public class EditQuestionAnswerResponse : Response
    {
    }
    
    public class EditQuestionAnswerHandler : BaseHandler<EditQuestionAnswerCommand, EditQuestionAnswerResponse>
    {

        IRepository<DbEntities.QuestionAnswer> _repository;
        public EditQuestionAnswerHandler(IRepository<DbEntities.QuestionAnswer> repository)
        {
            _repository = repository;
        }
        protected override EditQuestionAnswerResponse Handle(EditQuestionAnswerCommand command)
        {

            var response = new EditQuestionAnswerResponse
            {

                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Request is null.");
            var validationResult = new EditQuestionAnswerRequestValidator().Validate(command);
            if (!validationResult.IsValid)

            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = _repository.GetById(command.Id);
            if(record == null)
            {
                response.Code = ResponseCode.NotFound;
                response.Message = "Record not found";
                return response;
            }

            record.Answer = command.Answer; 
            HandlerUtilities.TimeStampRecord(record, command.UserId, false);
            _repository.Update(record);

            return response;
        }
    }
}
