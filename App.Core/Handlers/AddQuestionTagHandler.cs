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
    public class AddQuestionTagRequest : IRequest<AddQuestionTagResponse>, IUserRequest
    {
        
            [DataMember(Order = 1)]
            public string Title { get; set; }
            [DataMember(Order = 2)]
            public DateTime CreatedAt { get; set; }
            [DataMember(Order = 3)]
            public string CreatedBy { get; set; }
            [DataMember(Order = 4)]
            public DateTime UpdatedAt { get; set; }
            [DataMember(Order = 5)]
            public string UpdatedBy { get; set; }
            [DataMember(Order = 6)]
            public string UserId { get; set; }
    }

    public class AddQuestionTagRequestValidator : AbstractValidator<AddQuestionTagRequest>
    {
        public AddQuestionTagRequestValidator()
        {

        }
    }

    public class AddQuestionTagResponse : Response
    {
        [DataMember] public string Id { get; set; }
    }

    public class AddQuestionTagHandler : BaseHandler<AddQuestionTagRequest, AddQuestionTagResponse>
    {
        readonly IRepository<DbEntities.QuestionTag> _repository;

        public AddQuestionTagHandler(IRepository<DbEntities.QuestionTag> repository)
        {
            _repository = repository;
        }

        protected override AddQuestionTagResponse Handle(AddQuestionTagRequest request)
        {
            var response = new AddQuestionTagResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var validationResult = new AddQuestionTagRequestValidator().Validate(request);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = new DbEntities.QuestionTag();
            
            record.Title = request.Title; 
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
