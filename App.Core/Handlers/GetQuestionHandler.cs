using System;
using System.Collections.Generic;
using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using MediatR;
using System.Runtime.Serialization;
using App.Core.Factories;

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
        private readonly IQuestionsFactory _questionsFactory;

        public GetQuestionHandler(IQuestionsFactory questionsFactory)
        {
            _questionsFactory = questionsFactory;
        }

        protected override GetQuestionResponse Handle(GetQuestionRequest request)
        {
            return _questionsFactory.GetQuestion(request);
        }
    }
}