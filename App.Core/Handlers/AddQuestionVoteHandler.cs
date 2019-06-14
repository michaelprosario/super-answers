using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using MediatR;
using System.Runtime.Serialization;
using System;

namespace App.Core.Handlers
{
    public class AddQuestionVoteCommand : Command<AddQuestionVoteResponse>, IUserRequest
    {
        
            [DataMember(Order = 1)]
            public string QuestionId { get; set; }
            [DataMember(Order = 2)]
            public string UserId { get; set; }
    }

    public class AddQuestionVoteRequestValidator : AbstractValidator<AddQuestionVoteCommand>
    {
        public AddQuestionVoteRequestValidator()
        {
            RuleFor(r => r.QuestionId).NotEmpty();
            RuleFor(r => r.UserId).NotEmpty();            
        }
    }

    public class AddQuestionVoteResponse : Response
    {
        [DataMember] public string Id { get; set; }
    }

    public class AddQuestionVoteHandler : BaseHandler<AddQuestionVoteCommand, AddQuestionVoteResponse>
    {
        readonly IRepository<DbEntities.QuestionVote> _repository;
        readonly IQuestionsDataService _questionsDataService;

        public AddQuestionVoteHandler(
            IRepository<DbEntities.QuestionVote> repository,
            IQuestionsDataService questionsDataService
            )
        {
            _repository = repository;
            _questionsDataService = questionsDataService;
        }

        protected override AddQuestionVoteResponse Handle(AddQuestionVoteCommand command)
        {
            var response = new AddQuestionVoteResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Request is null.");
            var validationResult = new AddQuestionVoteRequestValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            if(_questionsDataService.QuestionVoteAlreadyExists(command.UserId, command.QuestionId)){
                response.Message = "User has already voted for this question";
                response.Code = ResponseCode.Success;
                return response;
            }

            var record = new DbEntities.QuestionVote();
            
            record.QuestionId = command.QuestionId; 
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
