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
    public class AddQuestionVoteRequest : IRequest<AddQuestionVoteResponse>, IUserRequest
    {
        
            [DataMember(Order = 1)]
            public string QuestionId { get; set; }
            [DataMember(Order = 2)]
            public DateTime CreatedAt { get; set; }
            [DataMember(Order = 3)]
            public string CreatedBy { get; set; }
            [DataMember(Order = 4)]
            public DateTime UpdatedAt { get; set; }
            [DataMember(Order = 5)]
            public string UpdatedBy { get; set; }
            public string UserId { get; set; }
    }

    public class AddQuestionVoteRequestValidator : AbstractValidator<AddQuestionVoteRequest>
    {
        public AddQuestionVoteRequestValidator()
        {

        }
    }

    public class AddQuestionVoteResponse : Response
    {
        [DataMember] public string Id { get; set; }
    }

    public class AddQuestionVoteHandler : BaseHandler<AddQuestionVoteRequest, AddQuestionVoteResponse>
    {
        readonly IRepository<DbEntities.QuestionVote> _repository;

        public AddQuestionVoteHandler(IRepository<DbEntities.QuestionVote> repository)
        {
            _repository = repository;
        }

        protected override AddQuestionVoteResponse Handle(AddQuestionVoteRequest request)
        {
            var response = new AddQuestionVoteResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var validationResult = new AddQuestionVoteRequestValidator().Validate(request);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = new DbEntities.QuestionVote();
            
            record.QuestionId = request.QuestionId; 
            record.CreatedAt = request.CreatedAt; 
            record.CreatedBy = request.CreatedBy; 
            record.UpdatedAt = request.UpdatedAt; 
            record.UpdatedBy = request.UpdatedBy; 
    
            HandlerUtilities.TimeStampRecord(record, request.UserId, true);
            var returnRecord = _repository.Add(record);
            response.Id = returnRecord.Id;

            return response;
        }
    }
}
