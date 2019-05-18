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
            public string UserId { get; set; }
    }

    public class AddQuestionTagRequestValidator : AbstractValidator<AddQuestionTagRequest>
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
