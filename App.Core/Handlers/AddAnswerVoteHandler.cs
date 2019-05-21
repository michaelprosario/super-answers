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
    public class AddAnswerVoteRequest : IRequest<AddAnswerVoteResponse>, IUserRequest
    {
        
            [DataMember(Order = 1)]
            public string QuestionAnswerId { get; set; }
            [DataMember(Order = 2)]
            public string UserId { get; set; }
    }

    public class AddAnswerVoteRequestValidator : AbstractValidator<AddAnswerVoteRequest>
    {
        public AddAnswerVoteRequestValidator()
        {
            RuleFor(r => r.QuestionAnswerId).NotEmpty();
            RuleFor(r => r.UserId).NotEmpty();            
        }
    }

    public class AddAnswerVoteResponse : Response
    {
        [DataMember] public string Id { get; set; }
    }

    public class AddAnswerVoteHandler : BaseHandler<AddAnswerVoteRequest, AddAnswerVoteResponse>
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

        protected override AddAnswerVoteResponse Handle(AddAnswerVoteRequest request)
        {
            var response = new AddAnswerVoteResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var validationResult = new AddAnswerVoteRequestValidator().Validate(request);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            if(_questionsDataService.AnswerVoteAlreadyExists(request.UserId, request.QuestionAnswerId)){
                response.Message = "User has already voted for this question";
                response.Code = ResponseCode.Success;
                return response;
            }

            var record = new DbEntities.QuestionAnswerVote();
            
            record.QuestionAnswerId = request.QuestionAnswerId; 
            record.CreatedAt = DateTime.Now; 
            record.CreatedBy = request.UserId; 
            record.UpdatedAt = DateTime.Now; 
            record.UpdatedBy = request.UserId; 
    
            HandlerUtilities.TimeStampRecord(record, request.UserId, true);
            var returnRecord = _repository.Add(record);
            response.Id = returnRecord.Id;

            return response;
        }
    }
}
