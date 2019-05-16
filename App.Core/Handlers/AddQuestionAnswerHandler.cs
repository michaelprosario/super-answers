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
    public class AddQuestionAnswerRequest : IRequest<AddQuestionAnswerResponse>, IUserRequest
    {
        
            [DataMember(Order = 1)]
            public string QuestionId { get; set; }
            [DataMember(Order = 2)]
            public string Answer { get; set; }
            [DataMember(Order = 3)]
            public DateTime CreatedAt { get; set; }
            [DataMember(Order = 4)]
            public string CreatedBy { get; set; }
            [DataMember(Order = 5)]
            public DateTime UpdatedAt { get; set; }
            [DataMember(Order = 6)]
            public string UpdatedBy { get; set; }
            [DataMember(Order = 7)]
            public int Votes { get; set; }
            [DataMember]
            public string UserId { get; set; }
    }

    public class AddQuestionAnswerRequestValidator : AbstractValidator<AddQuestionAnswerRequest>
    {
        public AddQuestionAnswerRequestValidator()
        {

        }
    }

    public class AddQuestionAnswerResponse : Response
    {
        [DataMember] public string Id { get; set; }
    }

    public class AddQuestionAnswerHandler : BaseHandler<AddQuestionAnswerRequest, AddQuestionAnswerResponse>
    {
        readonly IRepository<DbEntities.QuestionAnswer> _repository;

        public AddQuestionAnswerHandler(IRepository<DbEntities.QuestionAnswer> repository)
        {
            _repository = repository;
        }

        protected override AddQuestionAnswerResponse Handle(AddQuestionAnswerRequest request)
        {
            var response = new AddQuestionAnswerResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var validationResult = new AddQuestionAnswerRequestValidator().Validate(request);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = new DbEntities.QuestionAnswer();
            
            record.QuestionId = request.QuestionId; 
            record.Answer = request.Answer; 
            record.CreatedAt = request.CreatedAt; 
            record.CreatedBy = request.CreatedBy; 
            record.UpdatedAt = request.UpdatedAt; 
            record.UpdatedBy = request.UpdatedBy; 
            record.Votes = request.Votes; 
    
            HandlerUtilities.TimeStampRecord(record, request.UserId, true);
            var returnRecord = _repository.Add(record);
            response.Id = returnRecord.Id;

            return response;
        }
    }
}
