using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using System.Runtime.Serialization;
using System;

namespace App.Core.Handlers
{
    public class AddQuestionAnswerCommand : Command<AddQuestionAnswerResponse>, IUserRequest
    {
            [DataMember(Order = 1)]
            public string QuestionId { get; set; }
            [DataMember(Order = 2)]
            public string Answer { get; set; }
            [DataMember(Order = 3)]
            public string UserId { get; set; }
    }

    public class AddQuestionAnswerCommandValidator : AbstractValidator<AddQuestionAnswerCommand>
    {
        public AddQuestionAnswerCommandValidator()
        {
            RuleFor(x => x.Answer).NotEmpty();
            RuleFor(x => x.Answer).NotEmpty();
        }
    }

    public class AddQuestionAnswerResponse : Response
    {
        [DataMember] public string Id { get; set; }
    }

    public class AddQuestionAnswerHandler : BaseHandler<AddQuestionAnswerCommand, AddQuestionAnswerResponse>
    {
        readonly IRepository<DbEntities.QuestionAnswer> _repository;

        public AddQuestionAnswerHandler(IRepository<DbEntities.QuestionAnswer> repository)
        {
            _repository = repository;
        }

        protected override AddQuestionAnswerResponse Handle(AddQuestionAnswerCommand command)
        {
            var response = new AddQuestionAnswerResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Request is null.");
            var validationResult = new AddQuestionAnswerCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = new DbEntities.QuestionAnswer();
            
            record.QuestionId = command.QuestionId; 
            record.Answer = command.Answer; 
            record.CreatedAt = DateTime.Now;
            record.CreatedBy = command.UserId;
            record.UpdatedAt = DateTime.Now; 
            record.UpdatedBy = command.UserId; 
            record.Votes = 0; 
    
            HandlerUtilities.TimeStampRecord(record, command.UserId, true);
            var returnRecord = _repository.Add(record);
            response.Id = returnRecord.Id;

            return response;
        }
    }
}
