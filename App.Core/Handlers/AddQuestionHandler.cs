using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using MediatR;
using System.Runtime.Serialization;

namespace App.Core.Handlers
{
    public class AddQuestionRequest : IRequest<AddQuestionResponse>, IUserRequest
    {
        public string QuestionTitle { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public bool NotifyMeOnResponse { get; set; }
        public string UserId { get; set; }
    }

    public class AddQuestionRequestValidator : AbstractValidator<AddQuestionRequest>
    {
        public AddQuestionRequestValidator()
        {
            RuleFor(x => x.QuestionTitle).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class AddQuestionResponse : Response
    {
        [DataMember] public string Id { get; set; }
    }

    public class AddQuestionHandler : BaseHandler<AddQuestionRequest, AddQuestionResponse>
    {
        readonly IRepository<DbEntities.Question> _repository;

        public AddQuestionHandler(IRepository<DbEntities.Question> repository)
        {
            _repository = repository;
        }

        protected override AddQuestionResponse Handle(AddQuestionRequest request)
        {
            var response = new AddQuestionResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var validationResult = new AddQuestionRequestValidator().Validate(request);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = new DbEntities.Question
            {
                Content = request.Content,
                QuestionTitle = request.QuestionTitle
            };

            HandlerUtilities.TimeStampRecord(record, request.UserId, true);
            var returnRecord = _repository.Add(record);
            response.Id = returnRecord.Id;

            return response;
        }
    }
}