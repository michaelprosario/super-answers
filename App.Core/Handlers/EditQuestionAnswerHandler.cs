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
    public class EditQuestionAnswerRequest : IRequest<EditQuestionAnswerResponse>, IUserRequest
    {
        [DataMember(Order=1)]
        public string Id { get; set; }
        
        [DataMember(Order = 2)]
        public string QuestionId { get; set; }
        
        [DataMember(Order = 3)]
        public string Answer { get; set; }
        
        [DataMember(Order = 4)]
        public DateTime CreatedAt { get; set; }
        
        [DataMember(Order = 5)]
        public string CreatedBy { get; set; }
        
        [DataMember(Order = 6)]
        public DateTime UpdatedAt { get; set; }
        
        [DataMember(Order = 7)]
        public string UpdatedBy { get; set; }
        
        [DataMember(Order = 8)]
        public int Votes { get; set; }
        [DataMember(Order =9)]
        public string UserId { get; set; }
    }

    public class EditQuestionAnswerRequestValidator : AbstractValidator<EditQuestionAnswerRequest>
    {
        public EditQuestionAnswerRequestValidator()
        {

        }
    }

    [DataContract]
    public class EditQuestionAnswerResponse : Response
    {
    }
    
    public class EditQuestionAnswerHandler : BaseHandler<EditQuestionAnswerRequest, EditQuestionAnswerResponse>
    {

        IRepository<DbEntities.QuestionAnswer> _repository;
        public EditQuestionAnswerHandler(IRepository<DbEntities.QuestionAnswer> repository)
        {
            _repository = repository;
        }
        protected override EditQuestionAnswerResponse Handle(EditQuestionAnswerRequest request)
        {

            var response = new EditQuestionAnswerResponse
            {

                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var validationResult = new EditQuestionAnswerRequestValidator().Validate(request);
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
            record.Id = request.Id;    
            _repository.Update(record);

            HandlerUtilities.TimeStampRecord(record, request.UserId, false);
            _repository.Update(record);

            return response;
        }
    }
}
