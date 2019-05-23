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
               
        [DataMember(Order = 3)]
        public string Answer { get; set; }
        
        [DataMember(Order =9)]
        public string UserId { get; set; }
    }

    public class EditQuestionAnswerRequestValidator : AbstractValidator<EditQuestionAnswerRequest>
    {
        public EditQuestionAnswerRequestValidator()
        {
            RuleFor(r => r.Answer).NotEmpty();
            RuleFor(r => r.UserId).NotEmpty();
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

            var record = _repository.GetById(request.Id);
            if(record == null)
            {
                response.Code = ResponseCode.NotFound;
                response.Message = "Record not found";
                return response;
            }

            record.Answer = request.Answer; 
            HandlerUtilities.TimeStampRecord(record, request.UserId, false);
            _repository.Update(record);

            return response;
        }
    }
}
