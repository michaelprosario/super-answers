using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using System.Runtime.Serialization;
using System;

namespace App.Core.Handlers
{
    public class AddAnswerVoteCommand : Command<AddAnswerVoteResponse>, IUserRequest
    {    
            [DataMember(Order = 1)]
            public string QuestionAnswerId { get; set; }
            [DataMember(Order = 2)]
            public string UserId { get; set; }
    }

    public class AddAnswerVoteCommandValidator : AbstractValidator<AddAnswerVoteCommand>
    {
        public AddAnswerVoteCommandValidator()
        {
            RuleFor(r => r.QuestionAnswerId).NotEmpty();
            RuleFor(r => r.UserId).NotEmpty();            
        }
    }

    public class AddAnswerVoteResponse : Response
    {
        [DataMember] public string Id { get; set; }
    }

    public class AddAnswerVoteHandler : BaseHandler<AddAnswerVoteCommand, AddAnswerVoteResponse>
    {
        readonly IRepository<DbEntities.QuestionAnswerVote> _repository;
        readonly IQuestionsDataService _questionsDataService;

        public AddAnswerVoteHandler(
            IRepository<DbEntities.QuestionAnswerVote> repository,
            IQuestionsDataService questionsDataService
            )
        {
            _repository = repository;
            _questionsDataService = questionsDataService;
        }

        protected override AddAnswerVoteResponse Handle(AddAnswerVoteCommand command)
        {
            var response = new AddAnswerVoteResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Request is null.");
            var validationResult = new AddAnswerVoteCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            if(_questionsDataService.AnswerVoteAlreadyExists(command.UserId, command.QuestionAnswerId)){
                response.Message = "User has already voted for this question";
                response.Code = ResponseCode.Success;
                return response;
            }

            var record = new DbEntities.QuestionAnswerVote
            {
                QuestionAnswerId = command.QuestionAnswerId,
                CreatedAt = DateTime.Now,
                CreatedBy = command.UserId,
                UpdatedAt = DateTime.Now,
                UpdatedBy = command.UserId
            };

            HandlerUtilities.TimeStampRecord(record, command.UserId, true);
            var returnRecord = _repository.Add(record);
            response.Id = returnRecord.Id;

            return response;
        }
    }
}
