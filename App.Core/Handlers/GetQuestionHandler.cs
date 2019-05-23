using System.Collections.Generic;
using App.Core.Entities;
using App.Core.Interfaces;
using App.Core.Requests;
using MediatR;
using System.Runtime.Serialization;
using App.Core.Aggregates;

namespace App.Core.Handlers
{
    public class GetQuestionRequest : IRequest<GetQuestionResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    [DataContract]
    public class GetQuestionResponse : Response
    {
        [DataMember]
        public Question Question;

        [DataMember]
        public IList<QuestionAnswer> Answers { get; set; }
    }

    public class GetQuestionHandler : BaseHandler<GetQuestionRequest, GetQuestionResponse>
    {
        private readonly IQuestions _questions;

        public GetQuestionHandler(IQuestions questionsFactory)
        {
            _questions = questionsFactory;
        }

        protected override GetQuestionResponse Handle(GetQuestionRequest request)
        {
            return _questions.GetQuestion(request);
        }
    }
}