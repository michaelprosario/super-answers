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
            public string UserId { get; set; }
    }

    public class AddQuestionVoteRequestValidator : AbstractValidator<AddQuestionVoteRequest>
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
