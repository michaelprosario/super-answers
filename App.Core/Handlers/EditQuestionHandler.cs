using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using MediatR;
using System.Runtime.Serialization;

namespace App.Core.Handlers
{
    public class EditQuestionRequest : IRequest<EditQuestionResponse>, IUserRequest
    {
        public string QuestionTitle { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public bool NotifyMeOnResponse { get; set; }
        public string UserId { get; set; }
        public string QuestionId { get; set; }
    }

    public class EditQuestionRequestValidator : AbstractValidator<EditQuestionRequest>
    {
        public EditQuestionRequestValidator()
        {
            RuleFor(x => x.QuestionId).NotEmpty();
            RuleFor(x => x.QuestionTitle).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    [DataContract]
    public class EditQuestionResponse : Response
    {
        [DataMember]
        public string Id { get; set; }
    }
    
    public class EditQuestionHandler : BaseHandler<EditQuestionRequest, EditQuestionResponse>
    {
        IRepository<DbEntities.Question> _repository;
        public EditQuestionHandler(IRepository<DbEntities.Question> repository)
        {
            _repository = repository;
        }
        protected override EditQuestionResponse Handle(EditQuestionRequest request)
        {
            var response = new EditQuestionResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var validationResult = new EditQuestionRequestValidator().Validate(request);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = _repository.GetById(request.QuestionId);
            record.Content = request.Content;
            record.QuestionTitle = request.QuestionTitle;
            record.Tags = request.Tags;
       
            HandlerUtilities.TimeStampRecord(record, request.UserId, false);
            _repository.Update(record);

            return response;
        }
    }
}