using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using System.Runtime.Serialization;
using System;

namespace App.Core.Handlers
{
    public class AddQuestionTagCommand : Command<AddQuestionTagResponse>, IUserRequest
    {
        
            [DataMember(Order = 1)]
            public string Title { get; set; }
            public string UserId { get; set; }
    }

    public class AddQuestionTagRequestValidator : AbstractValidator<AddQuestionTagCommand>
    {
        public AddQuestionTagRequestValidator()
        {
            RuleFor( r => r.Title).NotEmpty();
        }
    }

    public class AddQuestionTagResponse : Response
    {
        [DataMember] public string Id { get; set; }
    }

    public class AddQuestionTagHandler : BaseHandler<AddQuestionTagCommand, AddQuestionTagResponse>
    {
        readonly IRepository<DbEntities.QuestionTag> _repository;

        public AddQuestionTagHandler(IRepository<DbEntities.QuestionTag> repository)
        {
            _repository = repository;
        }

        protected override AddQuestionTagResponse Handle(AddQuestionTagCommand command)
        {
            var response = new AddQuestionTagResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Request is null.");
            var validationResult = new AddQuestionTagRequestValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = new DbEntities.QuestionTag();
            
            record.Title = command.Title; 
            record.CreatedAt = DateTime.Now; 
            record.CreatedBy = command.UserId; 
            record.UpdatedAt = DateTime.Now; 
            record.UpdatedBy = command.UserId; 

            HandlerUtilities.TimeStampRecord(record, command.UserId, true);
            var returnRecord = _repository.Add(record);
            response.Id = returnRecord.Id;

            return response;
        }
    }
}
