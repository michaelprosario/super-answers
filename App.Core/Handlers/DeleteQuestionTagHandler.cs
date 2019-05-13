using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using MediatR;

namespace App.Core.Handlers
{
    public class DeleteQuestionTagRequest : IRequest<VoidResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    public class DeleteQuestionTagValidator : AbstractValidator<DeleteQuestionTagRequest>
    {
        public DeleteQuestionTagValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class DeleteQuestionTagHandler : BaseHandler<DeleteQuestionTagRequest, VoidResponse>
    {
        readonly IRepository<DbEntities.QuestionTag> _repository;
        public DeleteQuestionTagHandler(IRepository<DbEntities.QuestionTag> repository)
        {
            _repository = repository;
        }
        protected override VoidResponse Handle(DeleteQuestionTagRequest request)
        {
            var response = new VoidResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var validationResult = new DeleteQuestionTagValidator().Validate(request);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = _repository.GetById(request.Id);
            if (record == null) {
                response.Code = ResponseCode.NotFound;
                return response;
            }
            _repository.Delete(record);

            return response;
        }
    }
}

