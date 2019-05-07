using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Responses;
using App.Core.Utilities;
using MediatR;

namespace App.Core.Handlers
{
    public class AddQuestionHandler : RequestHandler<AddQuestionRequest, AddQuestionResponse>
    {
        IRepository<Question> _questionRepository;
        public AddQuestionHandler(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }
        protected override AddQuestionResponse Handle(AddQuestionRequest request)
        {
            var response = new AddQuestionResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var validationErrors = RequestValidator.Validate<AddQuestionRequest>(request);

            if (validationErrors.Count > 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                Question record = new Question
                {
                   Content = request.Content,
                   QuestionTitle = request.QuestionTitle
                };

                HandlerUtilities.TimeStampRecord(record, request.UserId);
                var returnRecord = _questionRepository.Add(record);
                response.Id = returnRecord.Id;
 
            }

            return response;
        }
    }
}