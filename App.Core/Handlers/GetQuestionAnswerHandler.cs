using App.Core.Entities;
using App.Core.Enums;
using App.Core.Factories;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using AutoMapper;
using MediatR;
using System.Runtime.Serialization;

namespace App.Core.Handlers
{
    public class GetQuestionAnswerRequest : IRequest<GetQuestionAnswerResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    [DataContract]
    public class GetQuestionAnswerResponse : Response
    {
        [DataMember] public QuestionAnswer QuestionAnswer;
        [DataMember] public Question Question;
    }

    public class GetQuestionAnswerHandler : BaseHandler<GetQuestionAnswerRequest, GetQuestionAnswerResponse>
    {
        readonly IRepository<DbEntities.QuestionAnswer> _repository;
        private readonly IMapper _mapper;
        private readonly IQuestionsFactory _questionsFactory;

        public GetQuestionAnswerHandler(IRepository<DbEntities.QuestionAnswer> repository, IMapper mapper, IQuestionsFactory questionsFactory)
        {
            _repository = repository;
            _mapper = mapper;
            _questionsFactory = questionsFactory;
        }

        protected override GetQuestionAnswerResponse Handle(GetQuestionAnswerRequest request)
        {
            var response = new GetQuestionAnswerResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var dbRecord = _repository.GetById(request.Id);
            if (dbRecord == null)
            {
                response.Code = ResponseCode.NotFound;
                return response;
            }

            var entity = _mapper.Map<QuestionAnswer>(dbRecord);

            response.QuestionAnswer = entity;

            var getQuestionRequest = new GetQuestionRequest()
            {
                Id = dbRecord.QuestionId,
                UserId = request.UserId
            };

            response.Question = _questionsFactory.GetQuestion(getQuestionRequest).Question;
            return response;
        }
    }
}
