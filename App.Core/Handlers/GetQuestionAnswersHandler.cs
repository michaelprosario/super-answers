using App.Core.Entities;
using App.Core.Enums;
using App.Core.Aggregates;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using AutoMapper;
using System.Runtime.Serialization;

namespace App.Core.Handlers
{
    public class GetQuestionAnswerQuery : Query<GetQuestionAnswerResponse>, IUserRequest
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

    public class GetQuestionAnswerHandler : BaseHandler<GetQuestionAnswerQuery, GetQuestionAnswerResponse>
    {
        readonly IRepository<DbEntities.QuestionAnswer> _repository;
        private readonly IMapper _mapper;
        private readonly IQuestions _questions;

        public GetQuestionAnswerHandler(IRepository<DbEntities.QuestionAnswer> repository, IMapper mapper, IQuestions questions)
        {
            _repository = repository;
            _mapper = mapper;
            _questions = questions;
        }

        protected override GetQuestionAnswerResponse Handle(GetQuestionAnswerQuery query)
        {
            var response = new GetQuestionAnswerResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(query, "Request is null.");
            var dbRecord = _repository.GetById(query.Id);
            if (dbRecord == null)
            {
                response.Code = ResponseCode.NotFound;
                return response;
            }

            var entity = _mapper.Map<QuestionAnswer>(dbRecord);

            response.QuestionAnswer = entity;

            var getQuestionRequest = new GetQuestionQuery()
            {
                Id = dbRecord.QuestionId,
                UserId = query.UserId
            };

            response.Question = _questions.GetQuestion(getQuestionRequest).Question;
            return response;
        }
    }
}
